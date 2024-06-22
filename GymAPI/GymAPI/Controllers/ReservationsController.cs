using Gym.BLL.Dto;
using Gym.BLL.Dto.Reservation;
using Gym.BLL.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost]
        public async Task<IActionResult> AddReservation([FromBody] ReservationRequestDto reservationDto)
        {
            if (reservationDto == null)
            {
                return BadRequest("Reservation data is null");
            }

            await _reservationService.AddReservation(reservationDto);
            return Ok();
        }

        [HttpGet("User")]
        public async Task<IActionResult> GetReservationsByUserId([FromQuery]string userId, [FromQuery] PageProperties pageProperties)
        {
            var reservations = await _reservationService.GetReservationsByUserId(userId, pageProperties);
            return Ok(reservations);
        }

        [HttpGet("Class")]
        public async Task<IActionResult> GetReservationsByClassId([FromQuery] int classId, [FromQuery] PageProperties pageProperties)
        {
            var reservations = await _reservationService.GetReservationsByClassId(classId, pageProperties);
            return Ok(reservations);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            await _reservationService.DeleteReservation(id);
            return Ok();
        }
    }
}
