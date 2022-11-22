using Core;
using Core.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QueroJobsWEB.Areas.Identity.Data;
using Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("QueroJobsContextConnection") ?? throw new InvalidOperationException("Connection string 'QueroJobsContextConnection' not found.");


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<QueroJobsContext>(
                options => options.UseMySQL(connectionString));

builder.Services.AddDbContext<IdentityContext>(
                options => options.UseMySQL(connectionString));

builder.Services.AddDefaultIdentity<UsersIdentity>(options =>
{
    // SignIn settings
    options.SignIn.RequireConfirmedAccount = false;
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;

    // Password settings
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;

    // Default User settings.
    options.User.AllowedUserNameCharacters =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;

    // Default Lockout settings
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
}).AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<IdentityContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.Cookie.Name = "YourAppCookieName";
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    options.LoginPath = "/Identity/Account/Login";
    // ReturnUrlParameter requires 
    options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
    options.SlidingExpiration = true;
});

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

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
