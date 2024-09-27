using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyPage.Data;
using MyPage.DataAccess.Management;
using MyPage.DataAccess;
using Microsoft.AspNetCore.Identity.UI.Services;
using MyPage.Services;
using MyPage.Models;
using MyPage.Hubs;
var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
services.AddDatabaseDeveloperPageExceptionFilter();

services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequireDigit = true;
})
    .AddEntityFrameworkStores<ApplicationDbContext>();

services.AddTransient<ISQLDataAccess, SQLDataAccess>();
services.AddTransient<IMasterDataRepo, MasterDataRepo>();
services.AddTransient<IEmailSender, EmailSender>();

services.AddSignalR();
services.AddHostedService<PingService>();

builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration);

builder.Services.AddControllersWithViews();

var app = builder.Build();

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.MapHub<PingHub>("/pingHub");
app.MapHub<MessageHub>("/messageHub");

app.Run();
