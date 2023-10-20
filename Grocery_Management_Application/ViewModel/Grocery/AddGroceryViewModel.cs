using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Grocery_Management_Application.ViewModel.Grocery
{
    public class AddGroceryViewModel
    {
        [Required(ErrorMessage = "Item Name is Mandatory")]
        public string ItemName { get; set; }
        [Required(ErrorMessage = "Item Discription is Mandatory")]
        public string ItemDescription { get; set; }
        [Required(ErrorMessage = "Item Type is Mandatory")]
        public string ItemType { get; set; }
        [Required(ErrorMessage = "Item Category id Mandatory")]
        public int CategoryId { get; set; }
        public List<SelectListItem> CategoryList { get; set; }
        [Required(ErrorMessage = "Item Price is Mandatory")]
        [Range(1, 10000000, ErrorMessage = "Product must be Greater than 0")]
        public double ItemPrice { get; set; }
    }
}
