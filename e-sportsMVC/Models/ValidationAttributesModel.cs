using System.ComponentModel.DataAnnotations;

namespace e_sportsMVC.Models
{
    [AttributeUsage(AttributeTargets.Property)]
    public class UniqueAttribute : ValidationAttribute
    {
        private readonly Type _entityType;
        private readonly string? _propertyName;

        public UniqueAttribute(Type entityType, string? propertyName = null)
        {
            _entityType = entityType;
            _propertyName = propertyName;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null || (value is string str && string.IsNullOrWhiteSpace(str)))
                return ValidationResult.Success;

            string targetProperty = _propertyName ?? validationContext.MemberName!;

            var type = validationContext.GetType;
            var idProperty = validationContext.ObjectType.GetProperty("ID");
            var currentId = idProperty?.GetValue(validationContext.ObjectInstance);
            

            bool exists = DataBaseModel.ChampionShips.Exists(c => c.ID.ToString() == idProperty.ToString());

            return exists ? new ValidationResult("This ") : ValidationResult.Success;
        }
    }
}
