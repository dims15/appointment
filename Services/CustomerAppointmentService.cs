using Appointments.DataAccess;
using Appointments.Entities;
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

        public AppointmentModel BookAppointment(CustomerAppointmentModel customerAppointment)
        {
            CustomerModel customer = _mapper.Map<CustomerModel>(customerAppointment);
            AppointmentModel appointment = _mapper.Map<AppointmentModel>(customerAppointment);

            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    CustomerModel existingCustomer = _customerService.RetrieveCustomerByEmail(customer.Email);

                    if (existingCustomer == null)
                    {
                        existingCustomer = _customerService.CreateCustomer(customer);
                    }

                    appointment.CustomerID = existingCustomer.Id;
                    AppointmentModel createdAppointment = _appointmentService.CreateAppointment(appointment);
                    transaction.Commit();
                    return createdAppointment;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public AppointmentModel RetrieveUserAppointment(string tokenNumber)
        {
            AppointmentEntity appointment = _dbContext.Appointments
            .FirstOrDefault(c => c.TokenNumber == tokenNumber);

            AppointmentModel appointmentModel = _mapper.Map<AppointmentModel>(appointment);
            appointmentModel.Customer = _customerService.RetrieveCustomerById(appointmentModel.CustomerID);
            return appointmentModel;
        }

        public List<CustomerAppointmentModel> GetAllAppointments()
        {
            throw new NotImplementedException();
        }
    }
}
