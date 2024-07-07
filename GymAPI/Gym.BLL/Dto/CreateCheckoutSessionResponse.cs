using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.BLL.Dto
{
    public class CreateCheckoutSessionResponse
    {
        public string SessionId { get; set; }
        public string PublicKey { get; set; }
    }
}
