using System.ComponentModel.DataAnnotations;

namespace PropertyManagement.Domain.Entities
{
    public class FaultReport
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        [MaxLength(50)]
        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedByOid { get; set; }
    }
}