using System.ComponentModel.DataAnnotations;

namespace LicenseApp.Models
{
  
    public class LicenseItem
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        /*public Application Application { get; set; }*/
        public int ItemId { get; set; }
        public Item Item { get; set; }

        [Range(0, 9999999.9999)]
        [DisplayFormat(DataFormatString = "{0:F4}", ApplyFormatInEditMode = true)]
        public decimal Quantity { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
        /*public string UnitName { get; set; }
        public string ItemName { get; set; }*/
    }

}
