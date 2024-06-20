using System.ComponentModel.DataAnnotations;

namespace LicenseApp.ViewModels
{

    public class LicenseDetailsViewModel
    {
        public string ApplicationNo { get; set; }
        [StringLength(50)]
        public string LicenseNo { get; set; }
        public string CompanyName { get; set; }
        public string SakhanName { get; set; }
        public List<LicenseItemViewModel> LicenseItems { get; set; }
    }

    /*public class LicenseItemViewModel
    {
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public string UnitName { get; set; }
    }*/
}
