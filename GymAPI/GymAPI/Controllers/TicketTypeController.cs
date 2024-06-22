using Gym.BLL.Dto.TicketType;
using Gym.BLL.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketTypeController : ControllerBase
    {
        private readonly ITicketTypeService _ticketTypeService;

        public TicketTypeController(ITicketTypeService ticketTypeService)
        {
            _ticketTypeService = ticketTypeService;
        }

        [HttpPost]
        public async Task<IActionResult> AddTicketType([FromBody] TicketTypeRequestDto ticketTypeDto)
        {
            await _ticketTypeService.AddTicketType(ticketTypeDto);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTicketTypes()
        {
            var ticketTypes = await _ticketTypeService.GetAllTicketTypes();
            return Ok(ticketTypes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicketTypeById(int id)
        {
            var ticketType = await _ticketTypeService.GetTicketTypeById(id);
            if (ticketType == null)
            {
                return NotFound();
            }
            return Ok(ticketType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicketType(int id, [FromBody] TicketTypeRequestDto ticketTypeDto)
        {
            if (ticketTypeDto == null)
            {
                return BadRequest("Ticket type data is null");
            }

            await _ticketTypeService.UpdateTicketType(id, ticketTypeDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicketType(int id)
        {
            await _ticketTypeService.DeleteTicketType(id);
            return NoContent();
        }
    }
}
