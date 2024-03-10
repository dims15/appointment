using Appointments.DataAccess;
using Appointments.Entities;
using Appointments.Model;
using Appointments.Model.ResponseBody;
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

        public CustomerEntity CreateCustomer(CustomerEntity customer)
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

        public CustomerEntity RetrieveCustomerByEmail(string email)
        {
            CustomerEntity customer = _dbContext.Customers
            .FirstOrDefault(c => c.Email == email);

            return customer;
        }

        public CustomerModel RetrieveCustomerById(int id)
        {
            CustomerEntity customer = _dbContext.Customers
            .FirstOrDefault(c => c.Id == id);

            return _mapper.Map<CustomerModel>(customer);
        }

        public List<CustomerWithListAppointmentsModel> RetrieveUsersByAppointmentDate(DateTime appointmentDate)
        {
            List<CustomerWithListAppointmentsModel> customers = _dbContext.Customers
            .Include(x => x.Appointments)
            .Where(c => c.Appointments.Any(a => a.AppointmentDate.Date >= appointmentDate.Date && a.AppointmentDate.Date < appointmentDate.AddDays(1).Date))
            .Select(c => new CustomerWithListAppointmentsModel
            {
                Id = c.Id,
                CustomerName = c.CustomerName,
                Email = c.Email,
                Phone = c.Phone,
                Appointments = c.Appointments
                    .Where(a => a.AppointmentDate.Date >= appointmentDate.Date && a.AppointmentDate.Date < appointmentDate.AddDays(1).Date)
                    .Select(a => new AppointmentModel
                    {
                        TokenNumber = a.TokenNumber,
                        AppointmentDate = a.AppointmentDate,
                        Status = a.Status,
                        CreatedOn = a.CreatedOn
                    })
                    .ToList()
            })
            .ToList();

            return customers;
        }
    }
}
