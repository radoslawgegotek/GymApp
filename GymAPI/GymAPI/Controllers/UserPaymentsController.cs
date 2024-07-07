using Gym.BLL.Dto;
using Gym.BLL.Dto.UserPayment;
using Gym.BLL.IServices;
using Gym.Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;

namespace GymAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPaymentsController : ControllerBase
    {
        private readonly IUserPaymentService _userPaymentService;
        private readonly IOptions<StripeSettings> _settings;
        private readonly ITicketTypeService _ticketTypeService;
        private readonly ITicketService _ticketService;

        public UserPaymentsController(
            IUserPaymentService userPaymentService,
            IOptions<StripeSettings> settings,
            ITicketTypeService ticketTypeService,
            ITicketService ticketService)
        {
            _userPaymentService = userPaymentService;
            _settings = settings;
            _ticketTypeService = ticketTypeService;
            _ticketService = ticketService;
        }

        [HttpPost]
        public async Task<IActionResult> AddUserPayment([FromBody] UserPaymentRequestDto userPaymentDto)
        {
            var ticketType = await _ticketTypeService.GetTicketTypeById(userPaymentDto.TicketTypeId);
            await _ticketService.AddTicket(new Gym.BLL.Dto.Ticket.TicketRequestDto
            {
                Title = ticketType.Name,
                TicketTypeId = ticketType.Id,
                ExpirationDate = userPaymentDto.ExpirationDate
            });

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
                {
                  "card",
                },
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment",
                SuccessUrl = "http://localhost:4200/checkout-succeeded",
                CancelUrl = "http://localhost:4200/checkout-fail",
            };

            var sessionLineItem = new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmount = (long)(ticketType.Price * 100),
                    Currency = "pln",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = ticketType.Name,
                        Description = ticketType.Description
                    },
                },
                Quantity = 1,
            };
            options.LineItems.Add(sessionLineItem);
            var service = new SessionService();
            try
            {
                var session = await service.CreateAsync(options);
                return Ok(new CreateCheckoutSessionResponse
                {
                    SessionId = session.Id,
                    PublicKey = _settings.Value.PublishableKey
                });
            }
            catch (StripeException e)
            {
                Console.WriteLine(e.StripeError.Message);
                return BadRequest();
            }
        }

        [HttpGet("byUserId/{userId}")]
        public async Task<IActionResult> GetUserPaymentsByUserId(string userId)
        {
            var userPayments = await _userPaymentService.GetUserPaymentsByUserId(userId);
            return Ok(userPayments);
        }
    }
}
