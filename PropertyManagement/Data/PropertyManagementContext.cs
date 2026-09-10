using Microsoft.EntityFrameworkCore;
using PropertyManagement.Domain.Entities;

namespace PropertyManagement.Data
{
    public class PropertyManagementContext : DbContext
    {
        public PropertyManagementContext(DbContextOptions<PropertyManagementContext> options) : base(options)
        {

        }

        public DbSet<FaultReport> FaultReports => Set<FaultReport>();
    }
}
