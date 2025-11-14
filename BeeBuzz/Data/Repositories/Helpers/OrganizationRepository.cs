using BeeBuzz.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BeeBuzz.Data.Repositories.Helpers
{
    public class OrganizationRepository : BeeBuzzGenericGenericRepository<Organization>
    {
        public OrganizationRepository(ApplicationDbContext db, ILogger<BeeBuzzGenericGenericRepository<Organization>> logger) : base(db, logger)
        {
        }
        public async Task<Organization?> GetOrganizationWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(r => r.Users)
                .Include(r => r.Beehives)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Organization?> GetUsersByOrganization(int id)
        {
            return await _dbSet
                .Include(r => r.Users)
                .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
