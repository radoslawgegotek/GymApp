using Gym.BLL.IRepositories;
using Gym.DAL.Context;

namespace Gym.BLL_EF.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly GymDbContext _context;

        public Repository(GymDbContext context)
        {
            _context = context;
        }

        public virtual async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
