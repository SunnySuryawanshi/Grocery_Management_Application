using System.ComponentModel.DataAnnotations;

namespace Grocery_Management_Application.ViewModel.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Email is Mandatory")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is Mandatory")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password and Confirm Password must be Same")]
        [DataType(DataType.Password)]   
        public string ConfirmPassword { get; set; }
    }
}
