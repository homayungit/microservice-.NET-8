using HG.Web.Service;
using HG.Web.Service.IService;
using HG.Web.Utility;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<IAuthService,AuthService>();
builder.Services.AddHttpClient<IMenuService,MenuService>();
builder.Services.AddHttpClient<ICompanyService,CompanyService>();

StaticDetails.AuthAPIBase = builder.Configuration["ServiceUrls:AuthAPI"];
StaticDetails.MenuApiBase = builder.Configuration["ServiceUrls:PermissionAPI"];
StaticDetails.ConfigAPIBase = builder.Configuration["ServiceUrls:ConfigAPI"];

builder.Services.AddScoped<IAuthService,AuthService>();
builder.Services.AddScoped<ITokenProvider, TokenProvider>();
builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromHours(10);
        options.LoginPath = "/Auth/Login";
        options.AccessDeniedPath = "/Auth/AccessDenied";
    });

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

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
