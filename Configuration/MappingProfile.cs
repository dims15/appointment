using Appointments.Entities;
using Appointments.Model;
using AutoMapper;
using System.Globalization;

namespace Appointments.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerAppointmentModel, CustomerEntity>();
            CreateMap<CustomerEntity, CustomerModel>();
            CreateMap<AppointmentEntity, AppointmentModel>();
            CreateMap<CustomerAppointmentModel, AppointmentEntity>()
                .ForMember(dest => dest.AppointmentDate, opt => opt.MapFrom(src => DateTime.ParseExact(src.AppointmentDate, "dd-MM-yyyy", CultureInfo.InvariantCulture)));
        }
    }
}
