using Appointments.Model;

namespace Appointments.Services
{
    public interface IAppointmentService
    {
        AppointmentModel CreateAppointment(AppointmentModel appointment);
    }
}
