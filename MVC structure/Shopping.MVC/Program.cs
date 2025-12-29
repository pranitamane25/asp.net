using Shopping.MVC.Repositories.Interfaces;
using Shopping.MVC.Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


// Add session service
builder.Services.AddSession();

// 🔴 THIS LINE WAS MISSING


builder.Services.AddSingleton<IProductsRepository, ProductRepository>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Enable session
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=Index}/{id?}");

app.Run();
