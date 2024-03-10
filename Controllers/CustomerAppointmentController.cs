using Appointments.Model;
using Appointments.Services;
using Microsoft.AspNetCore.Http;
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
                _customerAppointmentService.BookAppointment(customerAppointment);
                var data = new { Name = "John", Age = 30 };

                return Json(data);
            }
            catch
            {
                return View();
            }
        }
    }
}
