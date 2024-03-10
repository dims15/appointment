using Appointments.DataAccess;
using Appointments.Model;
using AutoMapper;

namespace Appointments.Services
{
    public class CustomerAppointmentService : ICustomerAppointmentService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;
        private readonly IAppointmentService _appointmentService;

        public CustomerAppointmentService(IMapper mapper,
            ApplicationDbContext dbContext,
            IAppointmentService appointmentService)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _appointmentService = appointmentService;
        }

        public void BookAppointment(CustomerAppointmentModel customerAppointment)
        {
            CustomerModel customer = _mapper.Map<CustomerModel>(customerAppointment);
            AppointmentModel appointment = _mapper.Map<AppointmentModel>(customerAppointment);

            _appointmentService.CreateAppointment(appointment);
        }

        public List<CustomerAppointmentModel> GetAllAppointments()
        {
            throw new NotImplementedException();
        }
    }
}
