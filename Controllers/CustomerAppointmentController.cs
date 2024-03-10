using Appointments.Entities;
using Appointments.Model;
using Appointments.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using Appointments.Model.ResponseBody;

namespace Appointments.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerAppointmentController : Controller
    {
        private readonly ICustomerAppointmentService _customerAppointmentService;
        private readonly ICustomerService _customerService;

        public CustomerAppointmentController(ICustomerAppointmentService customerAppointmentService, ICustomerService customerService)
        {
            _customerAppointmentService = customerAppointmentService;
            _customerService = customerService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CustomerAppointmentModel customerAppointment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                AppointmentEntity createdAppointment = _customerAppointmentService.BookAppointment(customerAppointment);

                return Ok(createdAppointment);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while creating appointment: {ex.Message}, {ex.StackTrace}");
                return StatusCode(500, "An error occurred while processing the request");
            }
        }

        [HttpGet("{tokenNumber}")]
        public IActionResult GetByTokenNumber(string tokenNumber)
        {
            try
            {
                AppointmentModel appointment = _customerAppointmentService.RetrieveUserAppointment(tokenNumber);

                if (appointment == null)
                {
                    return NotFound();
                }

                return Ok(appointment);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while retrieving appointment: {ex.Message}, {ex.StackTrace}");
                return StatusCode(500, "An error occurred while processing the request");
            }
        }

        [HttpGet("today")]
        public IActionResult GetUsersThatHaveAppointmentsByToday()
        {
            try
            {

                DateTime appointmentDate = DateTime.Today;
                List<CustomerWithListAppointmentsModel> usersWithAppointment = _customerService.RetrieveUsersByAppointmentDate(appointmentDate);

                return Ok(usersWithAppointment);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while creating appointment: {ex.Message}, {ex.StackTrace}");
                return StatusCode(500, "An error occurred while processing the request");
            }
        }
    }
}
