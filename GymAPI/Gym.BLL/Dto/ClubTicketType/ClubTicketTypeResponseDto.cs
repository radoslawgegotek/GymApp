using Gym.BLL.Dto.Club;
using Gym.BLL.Dto.TicketType;

namespace Gym.BLL.Dto.ClubTicketType
{
    public class ClubTicketTypeResponseDto
    {
        public int Id { get; set; }
        public TicketTypeResponseDto TicketType { get; set; }
    }
}
