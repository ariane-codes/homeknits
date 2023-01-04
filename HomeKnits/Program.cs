using HomeKnits.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<HomeKnitsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HomeKnitsContext") ?? throw new InvalidOperationException("Connection string 'HomeKnitsContext' not found.")));

// Add services to the container.
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<HomeKnitsContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var userSeedScope = app.Services.CreateScope())
{
    var userSeedservices = userSeedScope.ServiceProvider;
    await UserSeedData.Initialize(userSeedservices);
}

using (var productSeedScope = app.Services.CreateScope())
{
    var productSeedServices = productSeedScope.ServiceProvider;
    await ProductSeedData.Initialize(productSeedServices);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();
