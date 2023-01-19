using Microsoft.EntityFrameworkCore;
using Task_1._0.Models;
using Task_1._0.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Add DbContext Services
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Con")    )
);

//Add ProductRepository to Services
builder.Services.AddScoped<ProductRepository>();

//Add SupplierRepository to Services
builder.Services.AddScoped<SupplierRepository>();

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
    pattern: "{controller=Product}/{action=ShowAll}/{id?}");

app.Run();
