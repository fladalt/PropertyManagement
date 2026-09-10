using PropertyManagement.Application.DTOs;
using PropertyManagement.Application.Interfaces;
using PropertyManagement.Data.Interfaces;
using PropertyManagement.Domain.Entities;
using System.Security.Cryptography;

namespace PropertyManagement.Application.Services
{
    public class FaultReportService : IFaultReportService
    {
        private readonly IFaultReportRepo _repo;

        public FaultReportService(IFaultReportRepo repo)
        {
            _repo = repo;
        }

        public async Task CreateFaultReport(CreateFaultReportDTO faultReportRequest, string oid)
        {
            FaultReport faultReport = new FaultReport
            {
                Title = faultReportRequest.Title,
                Description = faultReportRequest.Description,
                Status = faultReportRequest.Status,
                CreatedAt = DateTime.UtcNow,
                CreatedByOid = oid
            };

            await _repo.CreateFaultReport(faultReport);
        }

        public async Task<bool> DeleteFaultReport(int id)
        {
            FaultReport? report = await _repo.GetFaultReportById(id);

            if (report == null)
            {
                return false;
            }

            await _repo.DeleteFaultReport(report);
            return true;
        }

        public async Task<List<FaultReport>> GetAllFaultReports(string? oid)
        {
            if (oid == null)
            {
                return await _repo.GetAllFaultReports();
            }

            return await _repo.GetAllFaultReportsByOid(oid);
        }

        public async Task<FaultReport?> GetFaultReportFromId(int id, string? oid)
        {
            if (oid == null)
            {
                return await _repo.GetFaultReportById(id);
            }

            FaultReport? report = await _repo.GetFaultReportById(id);

            if (report == null)
            {
                return null;
            }

            if (report.CreatedByOid == oid)
            {
                return report;
            }

            return null;
        }

        public async Task<bool> UpdateFaultReport(UpdateFaultReportDTO faultReportRequest)
        {
            FaultReport faultReport = new FaultReport
            {
                Id = faultReportRequest.Id,
                Title = faultReportRequest.Title,
                Description = faultReportRequest.Description,
                Status = faultReportRequest.Status
            };

            return await _repo.UpdateFaultReport(faultReport);
        }
    }
}
