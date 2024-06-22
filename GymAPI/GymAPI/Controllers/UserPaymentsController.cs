using Gym.BLL.Dto.UserPayment;
using Gym.BLL.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPaymentsController : ControllerBase
    {
        private readonly IUserPaymentService _userPaymentService;

        public UserPaymentsController(IUserPaymentService userPaymentService)
        {
            _userPaymentService = userPaymentService;
        }

        [HttpPost]
        public async Task<IActionResult> AddUserPayment([FromBody] UserPaymentRequestDto userPaymentDto)
        {
            if (userPaymentDto == null)
            {
                return BadRequest("User payment data is null");
            }

            await _userPaymentService.AddUserPayment(userPaymentDto);
            return Ok();
        }

        [HttpGet("byUserId/{userId}")]
        public async Task<IActionResult> GetUserPaymentsByUserId(string userId)
        {
            var userPayments = await _userPaymentService.GetUserPaymentsByUserId(userId);
            return Ok(userPayments);
        }
    }
}
