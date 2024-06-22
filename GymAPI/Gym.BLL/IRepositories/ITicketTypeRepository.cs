using Gym.Model.Models;

namespace Gym.BLL.IRepositories
{
    public interface ITicketTypeRepository : IRepository<TicketType>
    {
        Task<List<TicketType>> GetAllAsync();
        Task<TicketType> GetTicketTypeByIdAsync(int id);
    }
}
