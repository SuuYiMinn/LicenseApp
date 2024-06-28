using System.ComponentModel.DataAnnotations;
using System.Linq;
using LicenseApp.Data;

namespace LicenseApp.Validation
{
    public class UniqueGateCodeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var context = (AppDbContext)validationContext.GetService(typeof(AppDbContext));
            var entity = context.Gates.FirstOrDefault(e => e.GateCode == value.ToString());

            if (entity != null)
            {
                return new ValidationResult("GateCode must be unique.");
            }

            return ValidationResult.Success;
        }
    }
}
