using Core;
using Core.Services;
using Microsoft.EntityFrameworkCore;
using Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<QueroJobsContext>(
                options => options.UseMySQL("server=localhost;port=3306;user=root;password=123456;database=querojobs"));

builder.Services.AddTransient<ICompanyService, CompanyService>();
builder.Services.AddTransient<IVacancyService, VacancyService>();
builder.Services.AddTransient<IRoleService, RoleService>();
builder.Services.AddTransient<ICompetenceService, CompetenceService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    SeedingService seed = new SeedingService(app.Services.CreateScope().ServiceProvider.GetRequiredService<QueroJobsContext>());
    seed.Seed();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
