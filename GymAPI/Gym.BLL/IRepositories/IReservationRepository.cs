using Gym.BLL.Dto;
using Gym.Model.Models;

namespace Gym.BLL.IRepositories
{
    public interface IReservationRepository : IRepository<Reservation>
    {
        Task<List<Reservation>> GetReservationsByUserId(string userId, PageProperties pageProperties);
        Task<List<Reservation>> GetReservationsByClassId(int classId, PageProperties pageProperties);
    }
}
