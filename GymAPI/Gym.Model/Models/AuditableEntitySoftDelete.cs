namespace Gym.Model.Models
{
    public class AuditableEntitySoftDelete : AuditableEntity
    {
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string? DeletedBy { get; set; }
    }
}
