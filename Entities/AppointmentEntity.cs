using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Appointments.Entities
{
    public class AppointmentEntity
    {
        [Key]
        public string TokenNumber { get; set; }
        [JsonIgnore]
        public int CustomerID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
        public DateTime CreatedOn { get; set; }
        
        public CustomerEntity Customer { get; set; }

        public AppointmentEntity()
        {
            TokenNumber = GenerateToken();
        }

        private string GenerateToken()
        {
            Random random = new Random();
            int randomNumber = random.Next(10000);
            string randomString = randomNumber.ToString("D4");

            return $"A-{DateTime.Now:ddMMyyyyHHmmss}{randomString}";
        }
    }
}
