using System.ComponentModel.DataAnnotations.Schema;

namespace Gym.Model.Models
{
    public class Reservation : AuditableEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public AppUser? User { get; set; }
        public int ClassId { get; set; }
        [ForeignKey(nameof(ClassId))]
        public Class? Class { get; set; }
    }
}
