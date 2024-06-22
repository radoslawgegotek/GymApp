using Gym.BLL.Dto.Ticket;
using Gym.BLL.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet("{ticketTypeId}")]
        public async Task<IActionResult> GetTicketsByTicketTypeId([FromQuery]int ticketTypeId)
        {
            var tickets = await _ticketService.GetTicketsByTicketTypeId(ticketTypeId);
            return Ok(tickets);
        }
    }
}
