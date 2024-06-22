using System.ComponentModel.DataAnnotations.Schema;

namespace Gym.Model.Models
{
    public class ClubTicketType : AuditableEntity
    {
        public int Id { get; set; }

        public int ClubId { get; set; }
        [ForeignKey(nameof(ClubId))]
        public Club? Club { get; set; }

        public int TicketTypeId { get; set; }
        [ForeignKey(nameof(TicketTypeId))]
        public TicketType? TicketType { get; set; }
    }
}
