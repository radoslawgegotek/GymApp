using System.ComponentModel.DataAnnotations;

namespace Gym.Model.Models
{
    public class TicketType : AuditableEntitySoftDelete
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(2048)]
        public string Description { get; set; }
        public double Price { get; set; }
    }
}