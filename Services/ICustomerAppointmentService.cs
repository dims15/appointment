using Appointments.Model;


namespace Appointments.Services
{
    public interface ICustomerAppointmentService
    {
        List<CustomerAppointmentModel> GetAllAppointments();
        AppointmentModel BookAppointment(CustomerAppointmentModel customerAppointment);
        AppointmentModel RetrieveUserAppointment(string tokenNumber);
    }
}
