using System.ComponentModel.DataAnnotations;
using System.Linq;
using LicenseApp.Data;

namespace LicenseApp.Validation
{
    public class UniqueSakhanCodeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var context = (AppDbContext)validationContext.GetService(typeof(AppDbContext));
            var entity = context.Sakhans.FirstOrDefault(e => e.SakhanCode == value.ToString());

            if (entity != null)
            {
                return new ValidationResult("SakhanCode must be unique.");
            }

            return ValidationResult.Success;
        }
    }
}
