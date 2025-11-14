using BeeBuzz.Data.Entities;
using BeeBuzz.Data.Interfaces;

namespace BeeBuzz.Data.Repositories.Implementations
{
    public interface IBeehiveRepository : IBeeBuzzGenericRepository<Beehive>
    {
        Task<Beehive?> GetBeehiveAsync(int id);
    }
}
