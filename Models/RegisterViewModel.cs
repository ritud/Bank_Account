using System.ComponentModel.DataAnnotations;

namespace Bank_Account.Models
{
    public class RegisterViewModel
    {
        
         [Required]
         [MinLength(2,ErrorMessage="First Name should be 2 characters long")]
         [Display(Name="First Name")]
         [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use Characters only please")]
        public string first_name { get; set; }

         [Required]
         [MinLength(2,ErrorMessage="Last Name should be 2 characters long")]
         [Display(Name="Last Name")]
         [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use Characters only please")]
        public string last_name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name="Email")]
        public string email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Password")]
        [MinLength(8)]
        public string password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name="Confirm Password")]
        [Compare("password", ErrorMessage="Please enter same password")]
        public string confirm { get; set; }
    }
}