using Gym.BLL.IRepositories;
using Gym.DAL.Context;
using Gym.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Gym.BLL_EF.Repositories
{
    public class TicketRepository : Repository<Ticket>, ITicketRepository
    {
        private readonly GymDbContext _context;

        public TicketRepository(GymDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Ticket>> GetTicketsByTicketTypeId(int ticketTypeId)
        {
            return await _context.Tickets.Where(t => t.TicketTypeId == ticketTypeId).ToListAsync();
        }
    }
}
