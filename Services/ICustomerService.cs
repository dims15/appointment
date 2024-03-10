using Appointments.Entities;
using Appointments.Model;
using Appointments.Model.ResponseBody;

namespace Appointments.Services
{
    public interface ICustomerService
    {
        CustomerEntity CreateCustomer(CustomerEntity customer);
        CustomerEntity RetrieveCustomerByEmail(string email);
        CustomerModel RetrieveCustomerById(int id);
        List<CustomerWithListAppointmentsModel> RetrieveUsersByAppointmentDate(DateTime appointmentDate);
    }
}
