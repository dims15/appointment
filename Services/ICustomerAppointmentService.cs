using Appointments.Entities;
using Appointments.Model;


namespace Appointments.Services
{
    public interface ICustomerAppointmentService
    {
        List<CustomerAppointmentModel> GetAllAppointments();
        AppointmentEntity BookAppointment(CustomerAppointmentModel customerAppointment);
        AppointmentModel RetrieveUserAppointment(string tokenNumber);
    }
}
