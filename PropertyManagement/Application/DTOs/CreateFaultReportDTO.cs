namespace PropertyManagement.Application.DTOs
{
    public record CreateFaultReportDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
