using Core;
using Core.Services;
using Microsoft.EntityFrameworkCore;
using Services;
using Microsoft.AspNetCore.Identity;
using QueroJobsWEB.Data;
using QueroJobsWEB.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("QueroJobsWEBContextConnection") ?? throw new InvalidOperationException("Connection string 'QueroJobsWEBContextConnection' not found.");


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<QueroJobsContext>(
                options => options.UseMySQL(connectionString));

builder.Services.AddDefaultIdentity<QueroJobsWEBUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<QueroJobsContext>();

builder.Services.AddTransient<ICompanyService, CompanyService>();
builder.Services.AddTransient<IVacancyService, VacancyService>();
builder.Services.AddTransient<IRoleService, RoleService>();
builder.Services.AddTransient<ICompetenceService, CompetenceService>();
builder.Services.AddTransient<ICandidateService, CandidateService>();
builder.Services.AddTransient<ICourseService, CourseService>();
builder.Services.AddTransient<IVacancyService, VacancyService>();
builder.Services.AddTransient<IInstitutionService, InstitutionService>();



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
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
