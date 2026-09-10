using PropertyManagement.Application.DTOs;
using PropertyManagement.Domain.Entities;

namespace PropertyManagement.Application.Interfaces
{
    public interface IFaultReportService
    {
        Task<List<FaultReport>> GetAllFaultReports(string? oid);
        Task<FaultReport?> GetFaultReportFromId(int id, string? oid);
        Task CreateFaultReport(CreateFaultReportDTO faultReportRequest, string oid);
        Task<bool> UpdateFaultReport(UpdateFaultReportDTO faultReportRequest);
        Task<bool> DeleteFaultReport(int id);
    }
}
