using Appointments.Model;

namespace Appointments.Services
{
    public interface ICustomerService
    {
        CustomerModel CreateCustomer(CustomerModel customer);
        CustomerModel RetrieveCustomerByEmail(string email);
        CustomerModel RetrieveCustomerById(int id);
    }
}
