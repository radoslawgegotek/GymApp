using Gym.BLL.Dto;
using Gym.BLL.Dto.Club;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.BLL.IServices
{
    public interface IClubService
    {
        Task AddClub(ClubRequestDto clubDto);
        Task<List<ClubResponseDto>> GetAllClubs(PageProperties pageProperties);
        Task<ClubResponseDto> GetClubById(int id);
        Task UpdateClub(int clubId, ClubRequestDto clubDto);
        Task DeleteClub(int id);
    }
}
