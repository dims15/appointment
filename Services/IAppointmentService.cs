using Appointments.Model;

namespace Appointments.Services
{
    public interface IAppointmentService
    {
        void CreateAppointment(AppointmentModel appointment);
    }
}
