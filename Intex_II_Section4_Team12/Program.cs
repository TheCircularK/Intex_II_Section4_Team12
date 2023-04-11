using Intex_II_Section4_Team12.Context;
using Intex_II_Section4_Team12.Data;
using Intex_II_Section4_Team12.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var identityConnectionString = builder.Configuration.GetConnectionString("IdentityConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(identityConnectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();

//Add mummy connecttion
var mummyConnectionString = builder.Configuration.GetConnectionString("MummyConnectionString");

builder.Services.AddDbContext<MummyContext>(options =>
    options.UseNpgsql(mummyConnectionString));

//Scoped services
builder.Services.AddControllers();
builder.Services.AddScoped<IMummyRepository, MummyRepository>();

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

app.UseAuthentication();
app.UseAuthorization();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "mummy",
        pattern: "mummy/getallburials/{pageNum}",
        defaults: new { Controller = "Mummy", action = "GetAllBurials", pageNum = 1 });

    endpoints.MapDefaultControllerRoute();

    endpoints.MapRazorPages();
});

app.MapRazorPages();

app.Run();
