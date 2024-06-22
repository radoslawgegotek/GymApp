using Gym.BLL.Dto.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.BLL.IServices
{
    public interface ITicketService
    {
        Task AddTicket(TicketRequestDto ticketDto);
        Task<List<TicketResponseDto>> GetTicketsByTicketTypeId(int ticketTypeId);
        Task UpdateTicket(int id, TicketRequestDto ticketDto);
    }
}
