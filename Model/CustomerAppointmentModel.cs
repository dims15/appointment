using Appointments.Entities;

namespace Appointments.Model
{
    public class CustomerAppointmentModel
    {
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public string Status { get; set; }
        public int? TokenNumber { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
