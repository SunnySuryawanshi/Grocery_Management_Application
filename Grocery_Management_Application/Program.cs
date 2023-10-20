using Grocery_Management_Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
string connectionString = builder.Configuration.GetConnectionString("GroceryConnectionString");
builder.Services.AddDbContext<GroceryDbContext>(options => options.UseSqlServer(connectionString));
//services.AddTransient<IGroceryRepository, GroceryRepository>();
//services.AddTransient<ICategoryRepository, CategoryRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Grocery}/{action=Index}/{id?}");

app.Run();
