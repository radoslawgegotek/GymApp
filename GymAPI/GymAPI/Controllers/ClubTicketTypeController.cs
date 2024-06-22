using Gym.BLL.Dto.ClubTicketType;
using Gym.BLL.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubTicketTypeController : ControllerBase
    {
        private readonly IClubTicketTypeService _clubTicketTypeService;

        public ClubTicketTypeController(IClubTicketTypeService clubTicketTypeService)
        {
            _clubTicketTypeService = clubTicketTypeService;
        }

        [HttpPost]
        public async Task<IActionResult> AddClubTicketType([FromBody] ClubTicketTypeRequestDto clubTicketTypeDto)
        {
            if (clubTicketTypeDto == null)
            {
                return BadRequest("Club ticket type data is null");
            }

            await _clubTicketTypeService.AddClubTicketType(clubTicketTypeDto);
            return Ok();
        }

        [HttpGet("{clubId}")]
        public async Task<IActionResult> GetClubTicketTypesByClubId(int clubId)
        {
            var clubTicketTypes = await _clubTicketTypeService.GetClubTicketTypesByClubId(clubId);
            return Ok(clubTicketTypes);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClubTicketType(int id, [FromBody] ClubTicketTypeRequestDto clubTicketTypeDto)
        {
            if (clubTicketTypeDto == null)
            {
                return BadRequest("Club ticket type data is null");
            }

            await _clubTicketTypeService.UpdateClubTicketType(id, clubTicketTypeDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClubTicketType(int id)
        {
            await _clubTicketTypeService.DeleteClubTicketType(id);
            return NoContent();
        }
    }
}
