using System.ComponentModel.DataAnnotations;
using LicenseApp.Validation;
using Microsoft.EntityFrameworkCore;

namespace LicenseApp.Models
{
    [Index(nameof(ItemCode), IsUnique = true)]
    public class Item
    {
        public int Id { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        [UniqueItemCode]
        public string ItemCode { get; set; }
        public bool IsDeleted { get; set; } // Soft delete flag
    }
}

