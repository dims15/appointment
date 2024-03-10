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
            CreateMap<CustomerAppointmentModel, CustomerModel>();
            CreateMap<CustomerEntity, CustomerModel>();
            CreateMap<CustomerAppointmentModel, AppointmentModel>()
                .ForMember(dest => dest.AppointmentDate, opt => opt.MapFrom(src => DateTime.ParseExact(src.AppointmentDate, "dd-MM-yyyy", CultureInfo.InvariantCulture)));
        }
    }
}
