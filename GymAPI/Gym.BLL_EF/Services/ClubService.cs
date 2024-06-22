using AutoMapper;
using Gym.BLL.Dto;
using Gym.BLL.Dto.Club;
using Gym.BLL.IRepositories;
using Gym.BLL.IServices;
using Gym.Model.Models;

namespace Gym.BLL_EF.Services
{
    public class ClubService : IClubService
    {
        private readonly IClubRepository _clubRepository;
        private readonly IMapper _mapper;

        public ClubService(IClubRepository clubRepository, IMapper mapper)
        {
            _clubRepository = clubRepository;
            _mapper = mapper;
        }

        public async Task AddClub(ClubRequestDto clubDto)
        {
            var club = _mapper.Map<Club>(clubDto);
            await _clubRepository.CreateAsync(club);
        }

        public async Task DeleteClub(int id)
        {
            var club = await _clubRepository.GetByIdAsync(id);
            if (club != null)
            {
                _clubRepository.Delete(club);
            }
        }

        public async Task<List<ClubResponseDto>> GetAllClubs(PageProperties pageProperties)
        {
            var clubs = await _clubRepository.GetAllAsync(pageProperties);
            return _mapper.Map<List<ClubResponseDto>>(clubs);
        }

        public async Task<ClubResponseDto> GetClubById(int id)
        {
            var club = await _clubRepository.GetClubByIdAsync(id);
            return _mapper.Map<ClubResponseDto>(club);
        }

        public async Task UpdateClub(int clubId, ClubRequestDto clubDto)
        {
            var club = await _clubRepository.GetByIdAsync(clubId);
            if (club != null)
            {
                _mapper.Map(clubDto, club);
                _clubRepository.Update(club);
            }
        }
    }
}
