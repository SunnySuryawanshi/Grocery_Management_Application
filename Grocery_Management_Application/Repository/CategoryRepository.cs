using Grocery_Management_Application.DBContext;
using Grocery_Management_Application.Models;

namespace Grocery_Management_Application.Repository
{
    public class CategoryRepository : ICategoryRepositorycs
    {
        GroceryDbContext _groceryDbContext;
        public CategoryRepository(GroceryDbContext groceryDbContext)
        {
            _groceryDbContext = groceryDbContext;
        }
        public List<Category> GetAllCategories()
        {
            return _groceryDbContext.Categories.ToList();
        }
    }
}
