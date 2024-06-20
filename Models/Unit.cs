using System.ComponentModel.DataAnnotations;
using LicenseApp.Validation;
using Microsoft.EntityFrameworkCore;

namespace LicenseApp.Models
{
    [Index(nameof(UnitCode), IsUnique = true)]
    public class Unit
    {
        public int Id { get; set; }
        [Required]
        public string UnitName { get; set; }
        [Required]
        [UniqueUnitCode]
        public string UnitCode { get; set; }
        public bool IsDeleted { get; set; } // Soft delete flag
    }
}
