using AutoMapper;
using Gym.BLL.Dto.TicketType;
using Gym.BLL.IRepositories;
using Gym.BLL.IServices;
using Gym.Model.Models;

namespace Gym.BLL_EF.Services
{
    public class TicketTypeService : ITicketTypeService
    {
        private readonly ITicketTypeRepository _ticketTypeRepository;
        private readonly IMapper _mapper;

        public TicketTypeService(ITicketTypeRepository ticketTypeRepository, IMapper mapper)
        {
            _ticketTypeRepository = ticketTypeRepository;
            _mapper = mapper;
        }

        public async Task AddTicketType(TicketTypeRequestDto ticketTypeDto)
        {
            var ticket = _mapper.Map<TicketType>(ticketTypeDto);
            await _ticketTypeRepository.CreateAsync(ticket);
        }

        public async Task DeleteTicketType(int id)
        {
            var ticketType = await _ticketTypeRepository.GetByIdAsync(id);
            if (ticketType != null)
            {
                _ticketTypeRepository.Delete(ticketType);
            }
        }

        public async Task<List<TicketTypeResponseDto>> GetAllTicketTypes()
        {
            var ticketTypes = await _ticketTypeRepository.GetAllAsync();
            return _mapper.Map<List<TicketTypeResponseDto>>(ticketTypes);
        }

        public async Task<TicketTypeResponseDto> GetTicketTypeById(int id)
        {
            var ticketType = await _ticketTypeRepository.GetTicketTypeByIdAsync(id);
            return _mapper.Map<TicketTypeResponseDto>(ticketType);
        }

        public async Task UpdateTicketType(int id, TicketTypeRequestDto ticketTypeDto)
        {
            var ticketType = await _ticketTypeRepository.GetByIdAsync(id);
            if (ticketType != null)
            {
                _mapper.Map(ticketTypeDto, ticketType);
                _ticketTypeRepository.Update(ticketType);
            }
        }
    }
}
