using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gym.Model.Models
{
    public class Class : AuditableEntity
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(2048)]
        public string Description { get; set; }
        public int Slots { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public int ClubId { get; set; }
        [ForeignKey(nameof(ClubId))]
        public Club? Club { get; set; }
    }
}
