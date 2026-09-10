namespace PropertyManagement.Application.DTOs
{
    public record FaultReportDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedByOid { get; set; }
    }
}
