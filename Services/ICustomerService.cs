using Appointments.Model;

namespace Appointments.Services
{
    public interface ICustomerService
    {
        void CreateCustomer(CustomerModel customer);
    }
}
