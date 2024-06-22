using Gym.BLL.Dto.ClubTicketType;

namespace Gym.BLL.IServices
{
    public interface IClubTicketTypeService
    {
        Task AddClubTicketType(ClubTicketTypeRequestDto clubTicketTypeDto);
        Task<List<ClubTicketTypeResponseDto>> GetClubTicketTypesByClubId(int clubId);
        Task UpdateClubTicketType(int id, ClubTicketTypeRequestDto clubTicketTypeDto);
        Task DeleteClubTicketType(int id);
    }
}
