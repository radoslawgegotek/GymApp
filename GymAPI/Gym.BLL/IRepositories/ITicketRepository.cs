using Gym.Model.Models;

namespace Gym.BLL.IRepositories
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        Task<List<Ticket>> GetTicketsByTicketTypeId(int ticketTypeId);
    }
}
