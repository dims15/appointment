namespace Appointments.Model
{
    public class CustomerListWithAppointmentsModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public IEnumerable<AppointmentUserModel> Appointments { get; set; }
    }
}
