using System.ComponentModel.DataAnnotations;
using LicenseApp.Models;

namespace LicenseApp.ViewModels
{

    public class LicenseItemViewModel
    {
        public int ApplicationId { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }

       

        [Range(0, 9999999.9999)]
        [DisplayFormat(DataFormatString = "{0:F4}", ApplyFormatInEditMode = true)]
        public decimal Quantity { get; set; }
        [Range(0, 9999999.9999)]
        [DisplayFormat(DataFormatString = "{0:F4}", ApplyFormatInEditMode = true)]
        public decimal Balance { get; set; }
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        


    }
}
