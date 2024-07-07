using Gym.BLL.Dto;
using Gym.BLL.IRepositories;
using Gym.DAL.Context;
using Gym.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Gym.BLL_EF.Repositories
{
    public class ClassRepository : Repository<Class>, IClassRepository
    {
        private readonly GymDbContext _context;

        public ClassRepository(GymDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Class>> GetClassesByGymId(int GymId, PageProperties pageProperties)
        {
            int offset = (pageProperties.PageNumber - 1) * pageProperties.PageSize;
            var list = await _context.Classes
                .Where(x => x.ClubId == GymId)
                .Skip(offset)
                .Take(pageProperties.PageSize)
                .ToListAsync();
            return list;
        }

        public async Task<List<Class>> GetClassesByClassId(int classId, PageProperties pageProperties)
        {
            int offset = (pageProperties.PageNumber - 1) * pageProperties.PageSize;
            var list = await _context.Classes
                .Where(x => x.Id == classId)
                .Skip(offset)
                .Take(pageProperties.PageSize)
                .ToListAsync();
            return list;
        }
    }
}
