using System.ComponentModel.DataAnnotations;

namespace Appointments.Model.Validation
{
    public class BookingDateMustBeTodayOrLater : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dateFormat = "dd-MM-yyyy";
            DateTime parsedDate;
            DateTime.TryParseExact(value?.ToString(), dateFormat, null, System.Globalization.DateTimeStyles.None, out parsedDate);
            if (parsedDate < DateTime.Today)
            {
                return new ValidationResult("The booking date must be today or later.");
            }

            return ValidationResult.Success;
        }
    }
}
