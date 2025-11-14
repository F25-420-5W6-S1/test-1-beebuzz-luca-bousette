using BeeBuzz.Data.Entities;
using BeeBuzz.Data.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;

namespace BeeBuzz.Data.Repositories.Helpers
{
    public class BeehiveRepository : BeeBuzzGenericGenericRepository<Beehive>
    {
        public BeehiveRepository(ApplicationDbContext db, ILogger<BeeBuzzGenericGenericRepository<Beehive>> logger) : base(db, logger)
        {
        }
        public async Task<Beehive?> GetBeehivesForOrganization(int organizationId)
        {
            return await _dbSet
                .FirstOrDefaultAsync(r => r.OrganizationId == organizationId);
        }
    }
}
