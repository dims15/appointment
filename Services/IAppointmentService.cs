using Appointments.Entities;
using Appointments.Model;

namespace Appointments.Services
{
    public interface IAppointmentService
    {
        AppointmentEntity CreateAppointment(AppointmentEntity appointment);
    }
}
