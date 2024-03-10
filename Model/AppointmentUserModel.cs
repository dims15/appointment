namespace Appointments.Model
{
    public class AppointmentUserModel
    {
        public string TokenNumber { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
