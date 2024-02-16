using Grocery_Management_Application.Controllers;
using Grocery_Management_Application.DBContext;
using Grocery_Management_Application.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//string connectionString = builder.Configuration.GetConnectionString("GroceryConnectionString");
builder.Services.AddDbContext<GroceryDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("GroceryConnectionString")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<GroceryDbContext>()
    .AddDefaultTokenProviders();


builder.Services.AddTransient<IGroceryRepositorycs, GroceryReposiitory>();
builder.Services.AddTransient<ICategoryRepositorycs, CategoryRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Grocery}/{action=Index}/{id?}");

app.Run();
