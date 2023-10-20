using Grocery_Management_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Grocery_Management_Application
{
    public class GroceryDbContext : DbContext
    {
        public GroceryDbContext(DbContextOptions<GroceryDbContext>options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set;}
        public DbSet<Grocery> Groceries { get; set; }
    }
}
