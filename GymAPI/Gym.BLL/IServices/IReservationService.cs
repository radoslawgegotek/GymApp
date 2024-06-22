using Gym.BLL.Dto;
using Gym.BLL.Dto.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.BLL.IServices
{
    public interface IReservationService
    {
        Task AddReservation(ReservationRequestDto reservationDto);
        Task<List<ReservationResponseDto>> GetReservationsByUserId(string userId, PageProperties pageProperties);
        Task<List<ReservationResponseDto>> GetReservationsByClassId(int classId, PageProperties pageProperties);
        Task DeleteReservation(int id);
    }
}
