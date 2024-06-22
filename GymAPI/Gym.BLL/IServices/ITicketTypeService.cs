using Gym.BLL.Dto.TicketType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.BLL.IServices
{
    public interface ITicketTypeService
    {
        Task AddTicketType(TicketTypeRequestDto ticketTypeDto);
        Task<List<TicketTypeResponseDto>> GetAllTicketTypes();
        Task<TicketTypeResponseDto> GetTicketTypeById(int id);
        Task UpdateTicketType(int id, TicketTypeRequestDto ticketTypeDto);
        Task DeleteTicketType(int id);
    }
}
