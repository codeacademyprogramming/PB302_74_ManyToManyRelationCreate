namespace Pustok.Models
{
    public class AuditEntity:BaseEntity
    {
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; } 
    }
}
