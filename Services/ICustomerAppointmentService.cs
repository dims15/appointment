using Appointments.Model;


namespace Appointments.Services
{
    public interface ICustomerAppointmentService
    {
        List<CustomerAppointmentModel> GetAllAppointments();
        void BookAppointment(CustomerAppointmentModel customerAppointment);
    }
}
