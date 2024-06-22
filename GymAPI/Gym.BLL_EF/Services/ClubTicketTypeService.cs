using AutoMapper;
using Gym.BLL.Dto.ClubTicketType;
using Gym.BLL.IRepositories;
using Gym.BLL.IServices;
using Gym.Model.Models;

namespace Gym.BLL_EF.Services
{
    public class ClubTicketTypeService : IClubTicketTypeService
    {
        private readonly IClubTicketTypeRepository _clubTicketTypeRepository;
        private readonly IMapper _mapper;

        public ClubTicketTypeService(IClubTicketTypeRepository clubTicketTypeRepository, IMapper mapper)
        {
            _clubTicketTypeRepository = clubTicketTypeRepository;
            _mapper = mapper;
        }

        public async Task AddClubTicketType(ClubTicketTypeRequestDto clubTicketTypeDto)
        {
            var clubTicketType = _mapper.Map<ClubTicketType>(clubTicketTypeDto);
            await _clubTicketTypeRepository.CreateAsync(clubTicketType);
        }

        public async Task<List<ClubTicketTypeResponseDto>> GetClubTicketTypesByClubId(int clubId)
        {
            var clubTicketTypes = await _clubTicketTypeRepository.GetClubTicketTypesByClubId(clubId);
            return _mapper.Map<List<ClubTicketTypeResponseDto>>(clubTicketTypes);
        }

        public async Task UpdateClubTicketType(int id, ClubTicketTypeRequestDto clubTicketTypeDto)
        {
            var clubTicketType = await _clubTicketTypeRepository.GetByIdAsync(id);
            if (clubTicketType != null)
            {
                _mapper.Map(clubTicketTypeDto, clubTicketType);
                _clubTicketTypeRepository.Update(clubTicketType);
            }
        }

        public async Task DeleteClubTicketType(int id)
        {
            var clubTicketType = await _clubTicketTypeRepository.GetByIdAsync(id);
            if (clubTicketType != null)
            {
                _clubTicketTypeRepository.Delete(clubTicketType);
            }
        }
    }
}
