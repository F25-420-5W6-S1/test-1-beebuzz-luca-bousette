using BeeBuzz.Data.Entities;
using BeeBuzz.Data.JsonTranslationFiles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;
using System.Text.Json;

namespace BeeBuzz.Data
{
    public class DbSeeder
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IWebHostEnvironment _env;

        public DbSeeder(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IWebHostEnvironment env)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _env = env;
        }

        public void Seed()
        {
            _context.Database.EnsureCreated();

            SeedRoles();
        }

        private void SeedRoles()
        {
            var roles = GetRoles();

            foreach (var role in roles)
            {
                if (!_roleManager.RoleExistsAsync(role.Name).Result)
                {
                    _roleManager.CreateAsync(new IdentityRole(role.Name)).Wait();
                }
            }
        }

        private void SeedOrganization()
        {
            //if (!_context.Organizatons.Any())
            //{
            //    var organizations = GetOrganization();

            //foreach (var organ in organizations)
            //{
            //    if (!_roleManager.RoleExistsAsync(role.Name).Result)
            //    {
            //        _roleManager.CreateAsync(new IdentityRole(role.Name)).Wait();
            //    }
            //}
        }

        private List<RoleSeed>? GetRoles()
        {
            string filePath = Path.Combine(_env.ContentRootPath, "Data", "SeedData", "roles.json");
            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<RoleSeed>>(json);
        }

        private List<OrganizationSeed>? GetOrganization()
        {
            string filePath = Path.Combine(_env.ContentRootPath, "Data", "SeedData", "organization.json");
            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<OrganizationSeed>>(json);
        }
    }
}
