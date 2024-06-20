using System.ComponentModel.DataAnnotations;
using System.Linq;
using LicenseApp.Data;

namespace LicenseApp.Validation
{
    public class UniqueUnitCodeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var context = (AppDbContext)validationContext.GetService(typeof(AppDbContext));
            var entity = context.Units.FirstOrDefault(e => e.UnitCode == value.ToString());

            if (entity != null)
            {
                return new ValidationResult("UnitCode must be unique.");
            }

            return ValidationResult.Success;
        }
    }
}
