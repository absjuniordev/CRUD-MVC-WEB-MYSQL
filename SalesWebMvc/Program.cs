using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalesWebMvc.Data;
using SalesWebMvc.Services;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SalesWebMvcContext>
    (options => options.UseMySql(
        "server=localhost; initial catalog=sales_web_mvc;uid=root;pwd=123456",
        ServerVersion.Parse("8.0.30-mysql")));

builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<SellerService>();
builder.Services.AddScoped<DepartmentService>();
builder.Services.AddScoped<SalesRecordService>();
// Add services to the container.
builder.Services.AddControllersWithViews();

DbContextOptionsBuilder<SalesWebMvcContext> dbContextOptions = new DbContextOptionsBuilder<SalesWebMvcContext>();
dbContextOptions.UseMySql("server=localhost; initial catalog=sales_web_mvc;uid=root;pwd=123456", ServerVersion.Parse("8.0.30-mysql"));
SalesWebMvcContext context = new SalesWebMvcContext(dbContextOptions.Options);
SeedingService seedingService = new SeedingService(context);
seedingService.Seed();

var enUs = new CultureInfo("en-US");
var localizationsOptions = new RequestLocalizationOptions()
{
    DefaultRequestCulture = new RequestCulture("en-US"),
    SupportedCultures = new List<CultureInfo> { enUs },
    SupportedUICultures = new List<CultureInfo> { enUs }
};


var app = builder.Build();

app.UseRequestLocalization(localizationsOptions);

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
