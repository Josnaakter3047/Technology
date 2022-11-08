using assignment.Models;
using Microsoft.EntityFrameworkCore;
using assignment.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ExpenseDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("con")));
builder.Services.AddScoped(typeof(IRepo<>), typeof(ImplementRepo<>));
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
