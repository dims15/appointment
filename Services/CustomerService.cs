using Appointments.DataAccess;
using Appointments.Entities;
using Appointments.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Appointments.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly IMapper _mapper;

        public CustomerService(IMapper mapper,
            ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public CustomerModel CreateCustomer(CustomerModel customer)
        {
            _dbContext.Customers.Add(customer);

            try
            {
                _dbContext.SaveChanges();
                Console.WriteLine("Customer saved successfully.");
                return customer;
            }
            catch
            {
                throw;
            }
        }

        public CustomerModel RetrieveCustomerByEmail(string email)
        {
            CustomerEntity customer = _dbContext.Customers
            .FirstOrDefault(c => c.Email == email);

            return _mapper.Map<CustomerModel>(customer);
        }

        public CustomerModel RetrieveCustomerById(int id)
        {
            CustomerEntity customer = _dbContext.Customers
            .FirstOrDefault(c => c.Id == id);

            return _mapper.Map<CustomerModel>(customer);
        }
    }
}
