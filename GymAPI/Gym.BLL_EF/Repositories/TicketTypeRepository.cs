using Gym.BLL.IRepositories;
using Gym.DAL.Context;
using Gym.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Gym.BLL_EF.Repositories
{
    public class TicketTypeRepository : Repository<TicketType>, ITicketTypeRepository
    {
        private readonly GymDbContext _context;

        public TicketTypeRepository(GymDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<TicketType>> GetAllAsync()
        {
            return await _context.TicketTypes.ToListAsync();
        }

        public async Task<TicketType> GetTicketTypeByIdAsync(int id)
        {
            return await _context.TicketTypes.FirstOrDefaultAsync(tt => tt.Id == id);
        }
    }
}
