using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.BLL.Dto.UserPayment
{
    public class UserPaymentResponseDto
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string UserId { get; set; }
    }
}
