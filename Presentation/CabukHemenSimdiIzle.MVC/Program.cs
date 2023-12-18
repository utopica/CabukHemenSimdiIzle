using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CabukHemenSimdiIzle.Domain.Entities.Identity;
using CabukHemenSimdiIzle.Persistence.Contexts;
using Resend;
using FluentValidation.AspNetCore;
using CabukHemenSimdiIzle.MVC.Validators;
using CabukHemenSimdiIzle.Persistence;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddControllersWithViews()
    .AddNToastNotifyToastr();

builder.Services.AddControllersWithViews().AddFluentValidation(x => {
    x.RegisterValidatorsFromAssemblyContaining<AuthRegisterValidator>();
    x.RegisterValidatorsFromAssemblyContaining<AuthLoginValidator>();
});

builder.Services.AddRepositoryServices();

// Add services to the container.
builder.Services.AddControllersWithViews();


// Add services to the container.
builder.Services
    .AddControllersWithViews()
    .AddNToastNotifyToastr();

//Email auth system

/*builder.Services.AddOptions();
builder.Services.AddHttpClient<ResendClient>();
builder.Services.Configure<ResendClientOptions>(o =>
{
    o.ApiToken = "re_U8CSgNW6_4pyb4BcXZTRj27wTQ9MpBaQu";
});
builder.Services.AddTransient<IResend, ResendClient>();*/


//Adding DbContext

var connectionString = builder.Configuration.GetSection("YetgenPostgreSQLDB").Value;

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(connectionString);
});
builder.Services.AddDbContext<IdentityDbContext>(options =>
{
    options.UseNpgsql(connectionString);
});

/*var domain = builder.Environment.IsDevelopment() ? "https://localhost:7206" : "https://your-production-domain.com";

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddSingleton(domain);*/



//Add Identity System

builder.Services.AddSession();

builder.Services.AddIdentity<User, Role>(options =>
{
    // User Password Options
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    // User Username and Email Options
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@$";
    options.User.RequireUniqueEmail = true;

}).AddEntityFrameworkStores<IdentityDbContext>()
    .AddTokenProvider<DataProtectorTokenProvider<User>>(TokenOptions.DefaultProvider);

builder.Services.Configure<SecurityStampValidatorOptions>(options =>
{
    options.ValidationInterval = TimeSpan.FromMinutes(30);
});


builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = new PathString("/Auth/Login");
    options.LogoutPath = new PathString("/Auth/Logout");
    options.Cookie = new CookieBuilder
    {
        Name = "CabukHemenSimdi",
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        SecurePolicy = CookieSecurePolicy.SameAsRequest // Always
    };
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = System.TimeSpan.FromDays(7);
    options.AccessDeniedPath = new PathString("/Auth/AccessDenied");
});

//builder.Services.AddControllersWithViews()
//    .AddRazorOptions(options =>
//    {
//        options.ViewLocationFormats.Add("/Views/{1}/{0}.cshtml");
//        options.ViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
//        // Add your custom view location format for Directors/AddAsync
//        options.ViewLocationFormats.Add("/Views/Directors/{0}.cshtml");
//    });



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

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Register}/{id?}");

app.Run();