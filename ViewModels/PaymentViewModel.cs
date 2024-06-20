using System.ComponentModel.DataAnnotations;

namespace LicenseApp.ViewModels
{
    public class PaymentViewModel

    {
        public int ApplicationId { get; set; }
        public string ApplicationNo { get; set; }
        public decimal ApplicationFees { get; set; }
        public decimal LicenseFees { get; set; }
        public decimal TransactionFees { get; set; }
        public decimal TotalFees { get; set; }
    }
}
