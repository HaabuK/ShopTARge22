using ShopTARge22.Data;
using Microsoft.EntityFrameworkCore;
using ShopTARge22.Core.ServiceInterface;
using ShopTARge22.ApplicationServices.Services;
using Microsoft.Extensions.FileProviders;
using ShopTARge22.Hubs;
using Microsoft.AspNetCore.Identity;
using ShopTARge22.Core.Domain;
using ShopTARge22.Security;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();

builder.Services.AddScoped<ISpaceshipsServices, SpaceshipsServices>();
builder.Services.AddScoped<IRealEstatesServices, RealEstatesServices>();
builder.Services.AddScoped<IKindergartensServices, KindergartensServices>();
builder.Services.AddScoped<IFileServices, FileServices>();
builder.Services.AddScoped<IWeatherForecastServices, WeatherForecastServices>();
builder.Services.AddScoped<IChuckNorrisServices, ChuckNorrisServices>();
builder.Services.AddScoped<IAccuWeatherServices, AccuWeatherServices>();
builder.Services.AddScoped<ICocktailServices, CocktailServices>();
builder.Services.AddScoped<IEmailServices, EmailServices>();
builder.Services.AddRazorPages();


builder.Services.AddDbContext<ShopTARge22Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("ShopTARge22")));
//options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequiredLength = 3;

    options.Lockout.MaxFailedAccessAttempts = 2;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
})
    .AddEntityFrameworkStores<ShopTARge22Context>()
    .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>("CustomEmailConfirmaation")
    .AddDefaultUI();

//All tokens
builder.Services.Configure<DataProtectionTokenProviderOptions>(o =>
o.TokenLifespan = TimeSpan.FromHours(5));

//email tokens confimration
builder.Services.Configure<CustomEmailConfigurationTokenProviderOptions>(o =>
o.TokenLifespan = TimeSpan.FromDays(3));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "multipleFileUpload")),
    RequestPath = "/multipleFileUpload"
});

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

