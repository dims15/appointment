using Appointments.DataAccess;
using Appointments.Model;
using AutoMapper;

namespace Appointments.Services
{
    public class CustomerAppointmentService : ICustomerAppointmentService
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentService _appointmentService;
        private readonly ICustomerService _customerService;

        public CustomerAppointmentService(IMapper mapper,
            IAppointmentService appointmentService,
            ICustomerService customerService)
        {
            _mapper = mapper;
            _appointmentService = appointmentService;
            _customerService = customerService;
        }

        public void BookAppointment(CustomerAppointmentModel customerAppointment)
        {
            CustomerModel customer = _mapper.Map<CustomerModel>(customerAppointment);
            AppointmentModel appointment = _mapper.Map<AppointmentModel>(customerAppointment);

            _customerService.CreateCustomer(customer);
            _appointmentService.CreateAppointment(appointment);
        }

        public List<CustomerAppointmentModel> GetAllAppointments()
        {
            throw new NotImplementedException();
        }
    }
}
