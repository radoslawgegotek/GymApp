using AutoMapper;
using Gym.BLL.Dto.Ticket;
using Gym.BLL.IRepositories;
using Gym.BLL.IServices;
using Gym.Model.Models;

namespace Gym.BLL_EF.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;

        public TicketService(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }

        public async Task AddTicket(TicketRequestDto ticketDto)
        {
            var ticket = _mapper.Map<Ticket>(ticketDto);
            await _ticketRepository.CreateAsync(ticket);
        }

        public async Task<List<TicketResponseDto>> GetTicketsByTicketTypeId(int ticketTypeId)
        {
            var tickets = await _ticketRepository.GetTicketsByTicketTypeId(ticketTypeId);
            return _mapper.Map<List<TicketResponseDto>>(tickets);
        }

        public async Task UpdateTicket(int id, TicketRequestDto ticketDto)
        {
            var ticket = await _ticketRepository.GetByIdAsync(id);
            if (ticket != null)
            {
                _mapper.Map(ticketDto, ticket);
                _ticketRepository.Update(ticket);
            }
        }
    }
}
