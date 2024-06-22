using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.BLL.Dto.Reservation
{
    public class ReservationRequestDto
    {
        public string UserId { get; set; }
        public int ClassId { get; set; }
    }
}
