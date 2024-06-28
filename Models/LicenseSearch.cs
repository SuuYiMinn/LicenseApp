using LicenseApp.Validation;
using System.ComponentModel.DataAnnotations;

namespace LicenseApp.Models
{
    public class LicenseSearch
    {
        public string LicenseNo { get; set; }
        public int ApplicationId { get; set; }
        public Application Application { get; set; } // Holds license details

        public int GateId { get; set; }
        public List<Gate> Gates { get; set; } // For dropdown
        /*public int LicenseItemId { get; set; }*/
        public List<LicenseItem> Items { get; set; } // Holds items details

        [Required]
        public string DriverName { get; set; }
        [Required(ErrorMessage = "Driver NRC is required.")]
        [NRCFormat(ErrorMessage = "Invalid NRC format. Format should be like 9/YaKaNa(Naing)123456.")]
        public string DriverNRC { get; set; }
        [Required]
        public string VehicleNo { get; set; }
    }
}
