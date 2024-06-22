using AutoMapper;
using Gym.BLL.Dto.UserPayment;
using Gym.BLL.IRepositories;
using Gym.BLL.IServices;
using Gym.Model.Models;

namespace Gym.BLL_EF.Services
{
    public class UserPaymentService : IUserPaymentService
    {
        private readonly IUserPaymentRepository _userPaymentRepository;
        private readonly IMapper _mapper;

        public UserPaymentService(IUserPaymentRepository userPaymentRepository, IMapper mapper)
        {
            _userPaymentRepository = userPaymentRepository;
            _mapper = mapper;
        }

        public async Task AddUserPayment(UserPaymentRequestDto userPaymentDto)
        {
            var userPayment = _mapper.Map<UserPayment>(userPaymentDto);
            await _userPaymentRepository.CreateAsync(userPayment);
        }

        public async Task<List<UserPaymentResponseDto>> GetUserPaymentsByUserId(string userId)
        {
            var userPayments = await _userPaymentRepository.GetUserPaymentsByUserId(userId);
            return _mapper.Map<List<UserPaymentResponseDto>>(userPayments);
        }
    }
}
