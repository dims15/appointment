using Appointments.DataAccess;
using Appointments.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Appointments.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerService(IMapper mapper,
            ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateCustomer(CustomerModel customer)
        {
            _dbContext.Customers.Add(customer);

            try
            {
                _dbContext.SaveChanges();
                Console.WriteLine("Customer saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while saving customer: {ex.Message}");
            }
        }
    }
}
