using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RotiMakan.Database;
using RotiMakan.Repository;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), options => options.EnableRetryOnFailure()));

builder.Services.AddIdentity<IdentityModel, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddScoped<IAuthenticateRepository, AuthenticateRepository>();
builder.Services.AddScoped<IDetailsRepository, DetailsRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
