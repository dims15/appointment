using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Appointments.Entities
{
    public class CustomerEntity
    {
        [Key]
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        [JsonIgnore]
        public List<AppointmentEntity> Appointments { get; set; }
    }
}
