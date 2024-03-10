using System.ComponentModel.DataAnnotations;

namespace Appointments.Model.Validation
{
    public class EmailOrPhoneRequiredAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (CustomerAppointmentModel)validationContext.ObjectInstance;

            if (string.IsNullOrEmpty(model.Email) && string.IsNullOrEmpty(model.Phone))
            {
                return new ValidationResult("Either Email or Phone is required.");
            }

            return ValidationResult.Success;
        }
    }
}
