using Gym.BLL.Dto;
using Gym.Model.Models;

namespace Gym.BLL.IRepositories
{
    public interface IClubRepository : IRepository<Club>
    {
        Task<Club> GetClubByIdAsync(int id);
        Task<List<Club>> GetAllAsync(PageProperties pageProperties);
    }
}
