using Appointments.Constant;
using Appointments.DataAccess;
using Appointments.Entities;
using Appointments.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Appointments.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public AppointmentService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public AppointmentEntity CreateAppointment(AppointmentEntity appointment)
        {
            appointment.Status = AppointmentStatus.Booked;
            appointment.CreatedOn = DateTime.Now;
            appointment.AppointmentDate = OffDayBookingChanger(appointment.AppointmentDate);

            _dbContext.Appointments.Add(appointment);

            try
            {
                _dbContext.SaveChanges();
                Console.WriteLine("Appointment saved successfully.");
                return appointment;
            }
            catch
            {
                throw;
            }
        }

        private DateTime OffDayBookingChanger(DateTime bookingDate)
        {
            if (bookingDate.DayOfWeek == DayOfWeek.Saturday || bookingDate.DayOfWeek == DayOfWeek.Sunday)
            {
                return OffDayBookingChanger(bookingDate.AddDays(1));
            }
            else
            {
                bool offDayIncludedInRecord = _dbContext.OffDays.Any(x => x.OffDayDate == bookingDate);

                if (offDayIncludedInRecord)
                {
                    return OffDayBookingChanger(bookingDate.AddDays(1));
                }
                else
                {
                    return bookingDate;
                }
            }
        }
    }
}
