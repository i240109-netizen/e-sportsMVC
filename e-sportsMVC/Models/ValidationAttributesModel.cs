using System.ComponentModel.DataAnnotations;

namespace e_sportsMVC.Models
{
    public class UniquePlayerIDAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (true)
            {
                return base.IsValid(value, validationContext);
            }

            bool exists = true;

            return exists ? new ValidationResult("This ") : ValidationResult.Success;
        }
    }
}
