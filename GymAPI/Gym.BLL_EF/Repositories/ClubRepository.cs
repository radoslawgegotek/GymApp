using Gym.BLL.Dto;
using Gym.BLL.IRepositories;
using Gym.DAL.Context;
using Gym.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Gym.BLL_EF.Repositories
{
    public class ClubRepository : Repository<Club>, IClubRepository
    {
        private readonly GymDbContext _context;

        public ClubRepository(GymDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Club>> GetAllAsync(PageProperties pageProperties)
        {
            int offset = (pageProperties.PageNumber - 1) * pageProperties.PageSize;
            return await _context.Gyms
                .Skip(offset)
                .Take(pageProperties.PageSize)
                .ToListAsync();
        }

        public async Task<Club> GetClubByIdAsync(int id)
        {
            return await _context.Gyms.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
