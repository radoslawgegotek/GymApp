using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gym.Model.Models
{
    public class Ticket : AuditableEntity
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        public DateTime ExpirationDate { get; set; }

        public int TicketTypeId { get; set; }
        [ForeignKey(nameof(TicketTypeId))]
        public TicketType? TicketType { get; set; }
    }
}
