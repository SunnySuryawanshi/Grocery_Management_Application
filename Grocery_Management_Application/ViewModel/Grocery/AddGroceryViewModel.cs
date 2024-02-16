using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Grocery_Management_Application.ViewModel.Grocery
{
    public class AddGroceryViewModel
    {

        [Required(ErrorMessage = "Item Name is Mandatory")]
        [Display(Name = "Name")]
        public string ItemName { get; set; }
        [Required(ErrorMessage = "Item Discription is Mandatory")]
        [Display(Name = "Description")]
        public string ItemDescription { get; set; }
        [Required(ErrorMessage = "Item Type is Mandatory")]
        [Display(Name = "Type")]
        public string ItemType { get; set; }

        [Required(ErrorMessage = "Item Category id Mandatory")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public List<SelectListItem> CategoryList { get; set; }

        [Required(ErrorMessage = "Item Price is Mandatory")]
        [Range(1, 10000000, ErrorMessage = "Product must be Greater than 0")]
        [Display(Name = "Price")]
        public double ItemPrice { get; set; }
        

    }
}
