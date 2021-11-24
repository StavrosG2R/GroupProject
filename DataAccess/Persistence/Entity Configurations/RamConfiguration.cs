using DataAccess.Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Persistence.Entity_Configurations
{
    public class RamConfiguration : EntityTypeConfiguration<RAM>
    {
        public RamConfiguration()
        {
            Property(r => r.Model)
              .IsRequired();

            Property(c => c.CompanyID)
                .IsRequired();
        }
    }
}
