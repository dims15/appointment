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

        public List<CustomerListWithAppointmentsModel> RetrieveUsersByAppointmentDate(DateTime appointmentDate)
        {
            List<CustomerListWithAppointmentsModel> customers = _dbContext.Customers
                .Include(x => x.Appointments)
                .Where(c => c.Appointments.Any(a => a.AppointmentDate.Date >= appointmentDate.Date && a.AppointmentDate.Date < appointmentDate.AddDays(1).Date))
                .Select(c => new CustomerListWithAppointmentsModel
                {
                    Id = c.Id,
                    CustomerName = c.CustomerName,
                    Email = c.Email,
                    Phone = c.Phone,
                    Appointments = c.Appointments
                        .Select(a => new AppointmentUserModel
                        {
                            TokenNumber = a.TokenNumber,
                            AppointmentDate = a.AppointmentDate,
                            Status = a.Status,
                            CreatedOn = a.CreatedOn
                        })
                })
                .ToList();

            return customers;
        }
    }
}
