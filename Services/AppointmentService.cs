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

        public void CreateAppointment(AppointmentModel appointment)
        {
            _dbContext.Appointments.Add(appointment);

            try
            {
                _dbContext.SaveChanges();
                Console.WriteLine("Appointment saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while saving appointment: {ex.Message}");
            }
        }
    }
}
