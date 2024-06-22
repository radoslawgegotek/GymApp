using System.ComponentModel.DataAnnotations.Schema;

namespace Gym.Model.Models
{
    public class UserPayment : AuditableEntity
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public AppUser? User { get; set; }
    }
}
