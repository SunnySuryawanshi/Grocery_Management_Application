using Grocery_Management_Application.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Grocery_Management_Application.DBContext
{
    public class GroceryDbContext : IdentityDbContext<IdentityUser>
    {
        public GroceryDbContext(DbContextOptions<GroceryDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Grocery> Groceries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Grocery>().ToTable("Groceries");
        }
    }
}
