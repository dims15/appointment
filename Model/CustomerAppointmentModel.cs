using Appointments.Entities;
using Appointments.Model.Validation;
using System.ComponentModel.DataAnnotations;

namespace Appointments.Model
{
    public class CustomerAppointmentModel
    {
        [Required(ErrorMessage = "Appointment date is required")]
        [DateFormat(ErrorMessage = "Invalid date format. Use dd-MM-yyyy")]
        public string AppointmentDate { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
