namespace Appointments.Model.ResponseBody
{
    public class CustomerWithListAppointmentsModel : CustomerModel
    {
        public IEnumerable<AppointmentModel> Appointments { get; set; }
    }
}
