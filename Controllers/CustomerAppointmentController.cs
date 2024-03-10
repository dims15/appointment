using Appointments.Model;
using Appointments.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Appointments.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerAppointmentController : Controller
    {
        private readonly ICustomerAppointmentService _customerAppointmentService;
        private readonly IAppointmentService _appointmentService;

        public CustomerAppointmentController(ICustomerAppointmentService customerAppointmentService, IAppointmentService appointmentService)
        {
            _customerAppointmentService = customerAppointmentService;
            _appointmentService = appointmentService;
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
