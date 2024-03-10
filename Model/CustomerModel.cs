using Appointments.Entities;

namespace Appointments.Model
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
    }
}
