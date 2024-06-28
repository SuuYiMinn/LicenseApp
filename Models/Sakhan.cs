using System.ComponentModel.DataAnnotations;
using LicenseApp.Validation;
using Microsoft.EntityFrameworkCore;

namespace LicenseApp.Models
{
    [Index(nameof(SakhanCode), IsUnique = true)]
    public class Sakhan
    {
        public int Id { get; set; }
        [Required]
        public string SakhanName { get; set; }
        [Required]
        public string SakhanShortName { get; set; }
        [Required]
        [UniqueSakhanCode]
        public string SakhanCode { get; set; }
        public bool IsDeleted { get; set; } // Soft delete flag
    }
}
