using Intex_II_Section4_Team12.Context;
using Intex_II_Section4_Team12.Data;
using Intex_II_Section4_Team12.Models;
using Intex_II_Section4_Team12.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var identityConnectionString = builder.Configuration.GetConnectionString("IdentityConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(identityConnectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Default Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 14;
    options.Password.RequiredUniqueChars = 1;
});

//Add mummy connecttion
var mummyConnectionString = builder.Configuration.GetConnectionString("MummyConnectionString");

builder.Services.AddDbContext<MummyContext>(options =>
    options.UseNpgsql(mummyConnectionString));

//Scoped services
builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddScoped<IMummyRepository, MummyRepository>();
builder.Services.AddScoped<IRecordRepository, RecordRepository>();
builder.Services.AddScoped<IPhotoRepository, PhotoRepository>();

builder.Services.AddScoped<MyApiRequestData>();

// Cookie Policy
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    // This lambda determines whether user consent for non-essential 
    // cookies is needed for a given request.
    options.CheckConsentNeeded = context => true;

    options.MinimumSameSitePolicy = SameSiteMode.None;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();

app.UseAuthentication();
app.UseAuthorization();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "mummy",
        pattern: "mummy/getallburials/{pageNum}",
        defaults: new { Controller = "Mummy", action = "GetAllBurials", pageNum = 1 });

    endpoints.MapDefaultControllerRoute();

    endpoints.MapRazorPages();
});

app.UseCookiePolicy();



app.Use(async (context, next) =>
{
    context.Response.Headers.Add("Content-Security-Policy", "default-src 'self'; connect-src 'self'; script-src 'self'; style-src 'self'; font-src 'self'; img-src 'self'; frame-src 'self';");
    await next();
});

// Admin Account Setup
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    // Check if the "Admin" role exists, if not, create it
    var adminRoleExists = await roleManager.RoleExistsAsync("Admin");
    if (!adminRoleExists)
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
    }

    // Check if the "Researcher" role exists, if not, create it
    var researchRoleExists = await roleManager.RoleExistsAsync("Researcher");
    if (!researchRoleExists)
    {
        await roleManager.CreateAsync(new IdentityRole("Researcher"));
    }

    // Create a new user
    var user = new IdentityUser
    {
        UserName = "admin@example.com",
        Email = "admin@example.com",
        EmailConfirmed = true
    };

    // Register the user
    var result = await userManager.CreateAsync(user, "PasswordPassword123!");

    // If the user is successfully created, assign the "Admin" role to the user
    if (result.Succeeded)
    {
        await userManager.AddToRoleAsync(user, "Admin");
    }
}

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area}/{controller=Home}/{action=Index}/{id?}");
});

app.MapRazorPages();

app.UseHsts();

app.Run();
