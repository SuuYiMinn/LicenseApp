﻿using System.ComponentModel.DataAnnotations;

namespace LicenseApp.ViewModels
{
    public class PaymentViewModel

    {
        public int ApplicationId { get; set; }
        public string ApplicationNo { get; set; }
        public int SakhanId { get; set; }
        [StringLength(50)]
        
        public string LicenseNo { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PaymentDate { get; set; }
        public decimal ApplicationFees { get; set; }
        public decimal LicenseFees { get; set; }
        public decimal TransactionFees { get; set; }
        public decimal TotalFees { get; set; }
    }
    public class PaymentListViewModel
    {
        public List<PaymentViewModel> Payments { get; set; }
    }
}
