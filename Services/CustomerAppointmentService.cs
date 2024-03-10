using Appointments.DataAccess;
using Appointments.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Appointments.Services
{
    public class CustomerAppointmentService : ICustomerAppointmentService
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentService _appointmentService;
        private readonly ICustomerService _customerService;
        private readonly ApplicationDbContext _dbContext;

        public CustomerAppointmentService(IMapper mapper,
            IAppointmentService appointmentService,
            ICustomerService customerService,
            ApplicationDbContext dbContext)
        {
            _mapper = mapper;
            _appointmentService = appointmentService;
            _customerService = customerService;
            _dbContext = dbContext;
        }

        public void BookAppointment(CustomerAppointmentModel customerAppointment)
        {
            CustomerModel customer = _mapper.Map<CustomerModel>(customerAppointment);
            AppointmentModel appointment = _mapper.Map<AppointmentModel>(customerAppointment);

            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    CustomerModel createdCustomer = _customerService.RetrieveCustomerByEmail(customer.Email);

                    if (createdCustomer == null)
                    {
                        createdCustomer = _customerService.CreateCustomer(customer);
                        if (createdCustomer == null)
                        {
                            transaction.Rollback();
                            return;
                        }
                    }

                    appointment.CustomerID = createdCustomer.Id;
                    _appointmentService.CreateAppointment(appointment);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public List<CustomerAppointmentModel> GetAllAppointments()
        {
            throw new NotImplementedException();
        }
    }
}
