using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.BLL.Dto.Classes
{
    public class ClassResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Slots { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int ClubId { get; set; }
    }
}
