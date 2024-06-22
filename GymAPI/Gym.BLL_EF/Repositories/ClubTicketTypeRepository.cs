using Gym.BLL.IRepositories;
using Gym.DAL.Context;
using Gym.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Gym.BLL_EF.Repositories
{
    public class ClubTicketTypeRepository : Repository<ClubTicketType>, IClubTicketTypeRepository
    {
        private readonly GymDbContext _context;

        public ClubTicketTypeRepository(GymDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<ClubTicketType>> GetClubTicketTypesByClubId(int clubId)
        {
            return await _context.ClubTicketTypes
                .Where(ctt => ctt.ClubId == clubId)
                .Include(x => x.Club)
                .Include(x => x.TicketType)
                .ToListAsync();
        }
    }
}
