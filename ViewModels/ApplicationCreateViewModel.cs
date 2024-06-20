using LicenseApp.Controllers;
using LicenseApp.Models;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace LicenseApp.ViewModels
{
    public class ApplicationCreateViewModel
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string LicenseNo { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }

       
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LastDate { get; set; }
        public int SakhanId { get; set; }
        public string ApplicationNo { get; set; }
        [Required]
        public string CompanyName { get; set; }

        //for show dropdown in frontend
        public List<Sakhan> Sakhans { get; set; }

        public List<Item> Items { get; set; }

        public List<Unit> Units { get; set; }
         
        public List<LicenseItemViewModel> LicenseItems { get; set; } = new List<LicenseItemViewModel>(); // Initialize here

    }
    /* public class LicenseItemViewModel
     {
        *//* public int ItemId { get; set; }
         public Item Item { get; set; }*/
    /*public int UnitId { get; set; }
    public Unit Unit { get; set; }*//*
    public string ItemName { get; set; }
    public int Quantity { get; set; }
    public string UnitName { get; set; }
}*/
}
