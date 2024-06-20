using LicenseApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

/*namespace LicenseApp.Models
{
    public class Application
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string ApplicationNo { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public int SakhanId { get; set; }
        public Sakhan Sakhan { get; set; }
        public List<LicenseItem> LicenseItems { get; set; }
    }

}*/
namespace LicenseApp.Models
{
    public class Application
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string ApplicationNo { get; set; }

        [StringLength(50)]
        public string LicenseNo { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }

       
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LastDate { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public int SakhanId { get; set; }
        public Sakhan Sakhan { get; set; }
        
        public List<LicenseItem> LicenseItems { get; set; }
      
    }

   /* public class LicenseItem
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public Application Application { get; set; }
        public int ItemId  {get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
    }*/
}

