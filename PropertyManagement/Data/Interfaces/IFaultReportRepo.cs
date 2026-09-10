using PropertyManagement.Domain.Entities;

namespace PropertyManagement.Data.Interfaces
{
    public interface IFaultReportRepo
    {
        Task<List<FaultReport>> GetAllFaultReports();
        Task<List<FaultReport>> GetAllFaultReportsByOid(string oid);
        Task<FaultReport?> GetFaultReportById(int id);
        Task CreateFaultReport(FaultReport faultReport);
        Task<bool> UpdateFaultReport(FaultReport faultReport);
        Task DeleteFaultReport(FaultReport faultReport);
    }
}
