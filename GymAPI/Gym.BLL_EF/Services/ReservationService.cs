using AutoMapper;
using Gym.BLL.Dto;
using Gym.BLL.Dto.Reservation;
using Gym.BLL.IRepositories;
using Gym.BLL.IServices;
using Gym.Model.Models;

namespace Gym.BLL_EF.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public ReservationService(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public async Task AddReservation(ReservationRequestDto reservationDto)
        {
            var reservation = _mapper.Map<Reservation>(reservationDto);
            await _reservationRepository.CreateAsync(reservation);
        }

        public async Task<List<ReservationResponseDto>> GetReservationsByUserId(string userId, PageProperties pageProperties)
        {
            var reservations = await _reservationRepository.GetReservationsByUserId(userId, pageProperties);
            return _mapper.Map<List<ReservationResponseDto>>(reservations);
        }

        public async Task<List<ReservationResponseDto>> GetReservationsByClassId(int classId, PageProperties pageProperties)
        {
            var reservations = await _reservationRepository.GetReservationsByClassId(classId, pageProperties);
            return _mapper.Map<List<ReservationResponseDto>>(reservations);
        }


        public async Task DeleteReservation(int id)
        {
            var reservation = await _reservationRepository.GetByIdAsync(id);
            if (reservation != null)
            {
                _reservationRepository.Delete(reservation);
            }
        }
    }
}
