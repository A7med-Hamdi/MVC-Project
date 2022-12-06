using Depenancy.Repositsry;
using Depenancy.Services;
using Depenancy.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Day2DBContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("database"))
) ;

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IEmployeerepo, Employeerepo>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

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
