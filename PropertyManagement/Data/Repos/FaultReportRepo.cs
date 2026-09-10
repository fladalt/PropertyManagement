using Microsoft.EntityFrameworkCore;
using PropertyManagement.Data.Interfaces;
using PropertyManagement.Domain.Entities;

namespace PropertyManagement.Data.Repos
{
    public class FaultReportRepo : IFaultReportRepo
    {
        private readonly PropertyManagementContext _context;

        public FaultReportRepo(PropertyManagementContext context)
        {
            _context = context;
        }

        public async Task CreateFaultReport(FaultReport faultReport)
        {
            _context.FaultReports.Add(faultReport);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFaultReport(FaultReport faultReport)
        {
            _context.FaultReports.Remove(faultReport);
            await _context.SaveChangesAsync();
        }

        public async Task<List<FaultReport>> GetAllFaultReports()
        {
            return await _context.FaultReports.ToListAsync();
        }

        public async Task<List<FaultReport>> GetAllFaultReportsByOid(string oid)
        {
            return await _context.FaultReports
                .Where(f => f.CreatedByOid.Equals(oid))
                .ToListAsync();
        }

        public async Task<FaultReport?> GetFaultReportById(int id)
        {
            return await _context.FaultReports.FindAsync(id);
        }

        public async Task<bool> UpdateFaultReport(FaultReport faultReport)
        {
            FaultReport? report = await _context.FaultReports.FindAsync(faultReport.Id);

            if (report != null)
            {
                report.Title = faultReport.Title;
                report.Description = faultReport.Description;
                report.Status = faultReport.Status;

                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
