using Core;
using Core.Services;
using Microsoft.EntityFrameworkCore;
using Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<QueroJobsContext>(
                options => options.UseMySQL(builder.Configuration.GetConnectionString("server=localhost;port=3306;user=root;password=admin;database=querojobs")));

builder.Services.AddTransient<ICompanyService, CompanyService>();
builder.Services.AddTransient<IVacancyService, VacancyService>();

var app = builder.Build();

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
