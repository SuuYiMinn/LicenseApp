using System.ComponentModel.DataAnnotations;
using System.Linq;
using LicenseApp.Data;

namespace LicenseApp.Validation
{
    public class UniqueItemCodeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var context = (AppDbContext)validationContext.GetService(typeof(AppDbContext));
            var entity = context.Items.FirstOrDefault(e => e.ItemCode == value.ToString());

            if (entity != null)
            {
                return new ValidationResult("ItemCode must be unique.");
            }

            return ValidationResult.Success;
        }
    }
}
