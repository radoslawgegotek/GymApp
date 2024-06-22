using Gym.BLL.Dto;
using Gym.BLL.Dto.Club;
using Gym.BLL.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubsController : ControllerBase
    {
        private readonly IClubService _clubService;

        public ClubsController(IClubService clubService)
        {
            _clubService = clubService;
        }

        [HttpPost]
        public async Task<IActionResult> AddClub([FromBody] ClubRequestDto clubDto)
        {
            if (clubDto == null)
            {
                return BadRequest("Club data is null");
            }

            await _clubService.AddClub(clubDto);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<ClubResponseDto>>> GetAllClubs([FromQuery] PageProperties pageProperties)
        {
            var clubs = await _clubService.GetAllClubs(pageProperties);
            return Ok(clubs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClubResponseDto>> GetClubById(int id)
        {
            var club = await _clubService.GetClubById(id);
            if (club == null)
            {
                return NotFound();
            }
            return Ok(club);
        }

        [HttpPut("{clubId}")]
        public async Task<IActionResult> UpdateClub([FromRoute]int clubId, [FromBody] ClubRequestDto clubDto)
        {
            if (clubDto == null)
            {
                return BadRequest("Club data is null");
            }

            await _clubService.UpdateClub(clubId, clubDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClub(int id)
        {
            await _clubService.DeleteClub(id);
            return NoContent();
        }
    }
}
