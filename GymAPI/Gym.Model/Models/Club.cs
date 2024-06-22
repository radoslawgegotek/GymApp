using System.ComponentModel.DataAnnotations;

namespace Gym.Model.Models
{
    public class Club : AuditableEntity
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(2048)]
        public string Description { get; set; }
        [MaxLength(100)]
        public string City { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
    }
}