using Grocery_Management_Application.Models;
using Grocery_Management_Application.Repository;
using Grocery_Management_Application.ViewModel.Grocery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Security.Cryptography.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace Grocery_Management_Application.Controllers
{
    [Authorize]
    public class GroceryController : Controller
    {
       

        ICategoryRepositorycs _categoryRepositorycs;
        IGroceryRepositorycs _groceryRepositorycs;
        public GroceryController(ICategoryRepositorycs categoryRepositorycs, IGroceryRepositorycs groceryRepositorycs)
        {
            _categoryRepositorycs = categoryRepositorycs;
            _groceryRepositorycs = groceryRepositorycs;
        }   
        public IActionResult Index()
        {
            var grocerys = _groceryRepositorycs.GetAllGrocery(User.Identity.Name);
            List<GroceryDetailViewModelcs> groceryDetailViewListModelcs = new List<GroceryDetailViewModelcs>();
            foreach(var grocery in grocerys)
            {
                GroceryDetailViewModelcs groceryDetailViewModelcs = new GroceryDetailViewModelcs
                {
                    Id = grocery.Id,
                    ItemName = grocery.ItemName,
                    ItemDescription = grocery.ItemDiscription,
                    ItemType = grocery.ItemType,
                    CategoryName = grocery.Category.CategoryName,
                    CretedDate = grocery.CreatedDate,
                    ItemPrice = grocery.ItemPrice,
                    CreatedBy = grocery.Createdby,
                };
                groceryDetailViewListModelcs.Add(groceryDetailViewModelcs);
            }
            return View(groceryDetailViewListModelcs);
        }
        [HttpGet]
        public IActionResult AddGrocery()
        {
            var addGroceryViewModel = new AddGroceryViewModel();

            var categories = _categoryRepositorycs.GetAllCategories();

            List<SelectListItem> categorySelectListItems = new List<SelectListItem>();
            foreach (var category in categories)
            {
                categorySelectListItems.Add(new SelectListItem { Text = category.CategoryName, Value = category.CategoryId.ToString() });
            }
            categorySelectListItems.Insert(0, new SelectListItem { Text = "--Select-Category--", Value = String.Empty });

            
            addGroceryViewModel.CategoryList = categorySelectListItems;
            return View(addGroceryViewModel);
        }

        [HttpPost]
        public IActionResult AddGrocery(AddGroceryViewModel addgroceryViewModel)
        {

            var addGroceryViewModel = new AddGroceryViewModel();
            var categories = _categoryRepositorycs.GetAllCategories();
            List<SelectListItem> categoriesSelectListItems = new List<SelectListItem>();

            foreach (var category in categories)
            {
                categoriesSelectListItems.Add(new SelectListItem { Text = category.CategoryName, Value = category.CategoryId.ToString() });
            }

            categoriesSelectListItems.Insert(0, new SelectListItem { Text = "--Select-Category--", Value = String.Empty });
            addGroceryViewModel.CategoryList = categoriesSelectListItems;

            ModelState.Remove(nameof(addgroceryViewModel.CategoryList));
           

            if (ModelState.IsValid)
            {
                var existingGrocery = _groceryRepositorycs.GetAllGrocery(User.Identity.Name);
                //var groceries = existingGrocery?.FirstOrDefault
                //    (
                //    g => g.ItemName.ToLower() == addGroceryViewModel.ItemName.ToLower() && 
                //    g.ItemType.ToLower() == addGroceryViewModel.ItemType.ToLower()
                //    );
                //if (groceries != null)
                //{
                //    ModelState.AddModelError("",$"{addGroceryViewModel.ItemName} with type {addGroceryViewModel.ItemType} is already exists");
                //    return View(addGroceryViewModel);
                //}
                var grocery = new Grocery
                {
                   ItemName = addgroceryViewModel.ItemName,
                   ItemDiscription = addgroceryViewModel.ItemDescription,
                   ItemType = addgroceryViewModel.ItemType,
                   CategoryId = addgroceryViewModel.CategoryId,
                   CreatedDate = DateTime.Now,
                   ItemPrice = addgroceryViewModel.ItemPrice,
                   Createdby = HttpContext.User.Identity.Name
                };

                var addedgrocery = _groceryRepositorycs.AddGrocery(grocery);
                return RedirectToAction("Index");
            }
            
                return View(addGroceryViewModel);
        }


        [HttpGet]
        public IActionResult UpdateGrocery(int Id)
        {
            var updateGroceryViewModel = new UpdateGroceryViewModel();
            var groceryToBeEdited = _groceryRepositorycs.GetGroceryById(Id);
            var categories = _categoryRepositorycs.GetAllCategories();
            List<SelectListItem> categorySelectListItems = new List<SelectListItem>();
            foreach(var category in categories)
            {
                categorySelectListItems.Add(new SelectListItem { Text = category.CategoryName, Value = category.CategoryId.ToString()});
            }
            categorySelectListItems.Insert(0, new SelectListItem { Text = "--Select-Category--", Value = String.Empty });
            updateGroceryViewModel.CategoryList = categorySelectListItems;
            updateGroceryViewModel.Id = groceryToBeEdited.Id;
            updateGroceryViewModel.ItemName = groceryToBeEdited.ItemName;
            updateGroceryViewModel.ItemDescription = groceryToBeEdited.ItemDiscription;
            updateGroceryViewModel.ItemType = groceryToBeEdited.ItemType;
            updateGroceryViewModel.CategoryId = groceryToBeEdited.CategoryId;
            updateGroceryViewModel.ItemPrice = groceryToBeEdited.ItemPrice;
            return View(updateGroceryViewModel);
        }
        [HttpPost]
        public IActionResult UpdateGrocery(int id, UpdateGroceryViewModel updateGroceryViewModel)
        {
            ModelState.Remove(nameof(updateGroceryViewModel.CategoryList));
            if (ModelState.IsValid)
            {
                Grocery grocery = new Grocery
                { 
                    ItemName = updateGroceryViewModel.ItemName,
                    ItemDiscription = updateGroceryViewModel.ItemDescription,
                    ItemType = updateGroceryViewModel.ItemType,
                    CategoryId = updateGroceryViewModel.CategoryId,
                    ItemPrice = updateGroceryViewModel.ItemPrice,
                };
                _groceryRepositorycs.UpdateGrocery(id, grocery);    
                return RedirectToAction("Index");
            }
            return View(updateGroceryViewModel);
        }
        [HttpGet]
        public IActionResult DeleteGrocery(int id)
        {
            var groceryToBeDeleted = _groceryRepositorycs.GetGroceryByIdwithCategory(id);
            var deleteGroceryViewModel = new DeleteGroceryViewModel
            {
                Id = groceryToBeDeleted.Id,
                ItemName = groceryToBeDeleted.ItemName,
                ItemDescription = groceryToBeDeleted.ItemDiscription,
                ItemType = groceryToBeDeleted.ItemType,
                CategoryName = groceryToBeDeleted.Category.CategoryName,
                ItemPrice = groceryToBeDeleted.ItemPrice
            };
            return View(deleteGroceryViewModel);
        }
        [HttpPost]
        public IActionResult DeleteGrocery(DeleteGroceryViewModel deleteGroceryViewModel)
        {
            _groceryRepositorycs.RemoveGrocery(deleteGroceryViewModel.Id);
            return RedirectToAction("Index");
        }
    }
}
