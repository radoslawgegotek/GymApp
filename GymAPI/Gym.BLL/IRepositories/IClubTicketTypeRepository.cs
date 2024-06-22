using Gym.Model.Models;

namespace Gym.BLL.IRepositories
{
    public interface IClubTicketTypeRepository : IRepository<ClubTicketType>
    {
        Task<List<ClubTicketType>> GetClubTicketTypesByClubId(int clubId);
    }
}
