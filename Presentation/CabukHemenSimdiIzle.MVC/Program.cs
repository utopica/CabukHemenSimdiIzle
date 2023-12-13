using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CabukHemenSimdiIzle.Domain.Entities.Identity;
using CabukHemenSimdiIzle.Persistence.Contexts;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
