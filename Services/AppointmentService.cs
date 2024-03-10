using Appointments.Constant;
using Appointments.DataAccess;
using Appointments.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Appointments.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationDbContext _dbContext;

        public AppointmentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public AppointmentModel CreateAppointment(AppointmentModel appointment)
        {
            appointment.Status = AppointmentStatus.Booked;
            appointment.CreatedOn = DateTime.Now;
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
    }
}
