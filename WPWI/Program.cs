using DAL.DbContext;
using DAL.DbInitializer;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using WPWI.Profiles;

var builder = WebApplication.CreateBuilder(args);

var dbstring = builder.Configuration.GetConnectionString("DBInfo");

builder.Services.AddSqlServer<AppDbContext>(dbstring);

builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IDbInitializeIr, DbInitializer>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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
