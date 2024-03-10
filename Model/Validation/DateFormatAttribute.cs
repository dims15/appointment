using System.ComponentModel.DataAnnotations;

namespace Appointments.Model.Validation
{
    public class DateFormatAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dateFormat = "dd-MM-yyyy";
            DateTime parsedDate;
            var isValid = DateTime.TryParseExact(value?.ToString(), dateFormat, null, System.Globalization.DateTimeStyles.None, out parsedDate);
            if (!isValid)
            {
                return new ValidationResult($"Invalid date format. Use {dateFormat}");
            }

            return ValidationResult.Success;
        }
    }
}
