using Grocery_Management_Application.DBContext;
using Grocery_Management_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Grocery_Management_Application.Repository
{
    public class GroceryReposiitory : IGroceryRepositorycs
    {
        GroceryDbContext _groceryDbContext;
        public GroceryReposiitory(GroceryDbContext groceryDbContext)
        {
            _groceryDbContext = groceryDbContext;
        }
        public Grocery AddGrocery(Grocery grocery)
        {
            _groceryDbContext.Groceries.Add(grocery);
            _groceryDbContext.SaveChanges();
            return grocery;
        }
        public List<Grocery> GetAllGrocery(string userName)
        {
           return _groceryDbContext.Groceries.Include(d => d.Category).Where(p => p.Createdby == userName).ToList();
        }
        public Grocery GetGroceryById(int id)
        {
            var ExistingGrocery = _groceryDbContext.Groceries.FirstOrDefault(x => x.Id == id);
            return ExistingGrocery;
        }
        public Grocery GetGroceryByIdwithCategory(int id)
        {
            var ExisitingGrocery = _groceryDbContext.Groceries.Include(a => a.Category).FirstOrDefault(d => d.Id == id);
            return ExisitingGrocery;
        }
        public void RemoveGrocery(int id)
        {
            var exisitingGrocery = _groceryDbContext.Groceries.FirstOrDefault(d => d.Id == id);
            _groceryDbContext.Groceries.Remove(exisitingGrocery);
            _groceryDbContext.SaveChanges();
        }
        public void UpdateGrocery(int id, Grocery grocery)
        {
            var ExisitingGrocery = _groceryDbContext.Groceries.FirstOrDefault(d => d.Id == id);
            if(ExisitingGrocery != null)
            {
                ExisitingGrocery.ItemName = grocery.ItemName;
                ExisitingGrocery.ItemDiscription = grocery.ItemDiscription;
                ExisitingGrocery.ItemType = grocery.ItemType;
                ExisitingGrocery.CategoryId = grocery.CategoryId;
                ExisitingGrocery.ItemPrice = grocery.ItemPrice;
                _groceryDbContext.SaveChanges();
            }
        }
    }
}
