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


//fix your forward to login page
builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.AccessDeniedPath = "/Accounts/AccessDenied";
    opt.LoginPath = "/Accounts/Login";
});

builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddAutoMapper(typeof(MappingProfile));


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

//make the dbinitializer work
var scope = app.Services.CreateScope();
var dbInit = scope.ServiceProvider.GetService<IDbInitializer>();
dbInit.InitializeAsync();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
