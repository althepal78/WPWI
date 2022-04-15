using DAL.DbContext;
using Microsoft.AspNetCore.Identity;

namespace DAL.DbInitializer
{
    public class DbInitializer : IDbInitializeIr
    {
        private readonly AppDbContext _db;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(AppDbContext db,
          RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _roleManager = roleManager;
        }

        public async Task InitializeAsync()
        {
            if (_db.Roles.Any(r => r.Name == "User")) return;
            await _roleManager.CreateAsync(new IdentityRole("User"));
            await _roleManager.CreateAsync(new IdentityRole("Planner"));
        }


    }
}





