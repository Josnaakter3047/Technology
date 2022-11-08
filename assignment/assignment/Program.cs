using assignment.Models;
using Microsoft.EntityFrameworkCore;
using assignment.Repository;
using Microsoft.AspNetCore.Identity;
using assignment.Data;
using assignment.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ExpenseDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("con")));
builder.Services.AddDbContext<MyDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("con")));
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<MyDbContext>();
builder.Services.AddScoped(typeof(IRepo<>), typeof(ImplementRepo<>));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
