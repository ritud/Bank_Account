using System.ComponentModel.DataAnnotations;

namespace Bank_Account.Models
{
    public class TransactionViewModel
    {
        
         [Required]
         [Display(Name="Deposit/Withdraw")]
        public string amount { get; set; }
    }
}
