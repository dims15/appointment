using System.ComponentModel.DataAnnotations;

namespace Appointments.Entities
{
    public class CustomerEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public List<AppointmentEntity> Appointments { get; set; }
    }
}
