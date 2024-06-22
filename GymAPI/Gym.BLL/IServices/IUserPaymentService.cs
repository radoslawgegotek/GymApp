using Gym.BLL.Dto.UserPayment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.BLL.IServices
{
    public interface IUserPaymentService
    {
        Task AddUserPayment(UserPaymentRequestDto userPaymentDto);
        Task<List<UserPaymentResponseDto>> GetUserPaymentsByUserId(string userId);
    }
}
