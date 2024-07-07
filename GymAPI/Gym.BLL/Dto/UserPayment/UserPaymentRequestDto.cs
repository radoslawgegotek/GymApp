using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.BLL.Dto.UserPayment
{
    public class UserPaymentRequestDto
    {
        public DateTime ExpirationDate { get; set; }
        public int TicketTypeId { get; set; }
    }
}
