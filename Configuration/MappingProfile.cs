using Appointments.Model;
using AutoMapper;

namespace Appointments.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerAppointmentModel, CustomerModel>();
            CreateMap<CustomerAppointmentModel, AppointmentModel>();
        }
    }
}
