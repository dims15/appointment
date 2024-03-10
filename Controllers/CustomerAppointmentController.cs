using Appointments.Model;
using Appointments.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;

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

            var data = new { Name = "John", Age = 30 };

            try
            {
                AppointmentModel createdAppointment = _customerAppointmentService.BookAppointment(customerAppointment);

                return Ok(createdAppointment);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while creating appointment: {ex.Message}, {ex.StackTrace}");
                return Json(data);
            }
        }
    }
}
