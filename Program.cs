using Microsoft.EntityFrameworkCore;
using WeatherAppMVC.Models;

var builder = WebApplication.CreateBuilder(args);

// Dodaj us³ugi do kontenera.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<WeatherContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("WeatherDatabase")));

var app = builder.Build();

// Skonfiguruj potok ¿¹dañ HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
