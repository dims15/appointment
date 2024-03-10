using Appointments.Model;
using Appointments.Services;
using Microsoft.AspNetCore.Mvc;

namespace Appointments.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerAppointmentController : Controller
    {
        private readonly ICustomerAppointmentService _customerAppointmentService;

        public CustomerAppointmentController(ICustomerAppointmentService customerAppointmentService)
        {
            _customerAppointmentService = customerAppointmentService;
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
                AppointmentModel createdAppointment = _customerAppointmentService.BookAppointment(customerAppointment);

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
                Console.WriteLine($"Error occurred while creating appointment: {ex.Message}, {ex.StackTrace}");
                return StatusCode(500, "An error occurred while processing the request");
            }
        }
    }
}
