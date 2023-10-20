using Grocery_Management_Application.Models;

namespace Grocery_Management_Application.Repository
{
    public interface IGroceryRepositorycs
    {
        List<Grocery> GetAllGrocery(string userName);
        Grocery AddGrocery(Grocery grocery);
        Grocery GetGroceryById(int id);
        Grocery GetGroceryByIdwithCategory(int id);
        void UpdateGrocery(int id, Grocery grocery);
        void RemoveGrocery(int id);
    }
}
