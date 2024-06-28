using LicenseApp.Models;
using LicenseApp.Validation;
using System.ComponentModel.DataAnnotations;

namespace LicenseApp.ViewModels
{
    public class GateCreateViewModel
    {
        public int Id { get; set; }
        [Required]
        public string GateName { get; set; }

        [Required]
        [UniqueGateCode]
        public string GateCode { get; set; }
        public bool IsDeleted { get; set; } // Soft delete flag

        public int SakhanId { get; set; }
        public string SakhanName { get; set; }
        //for show dropdown in frontend
        public List<Sakhan> Sakhans { get; set; }
    }
}
