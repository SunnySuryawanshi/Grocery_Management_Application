using System.ComponentModel.DataAnnotations;

namespace Grocery_Management_Application.ViewModel.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is Mandatory")]
        [Display(Name = "User Name")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Email is Mandatory")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
