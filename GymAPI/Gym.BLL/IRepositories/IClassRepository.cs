using Gym.BLL.Dto;
using Gym.Model.Models;

namespace Gym.BLL.IRepositories
{
    public interface IClassRepository : IRepository<Class>
    {
        Task<List<Class>> GetClassesByGymId(int GymId, PageProperties pageProperties);
        Task<List<Class>> GetClassesByClassId(int classId, PageProperties pageProperties);
    }
}
