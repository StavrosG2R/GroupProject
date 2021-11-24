using DataAccess.Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Persistence.Entity_Configurations
{
    public class CpuConfiguration : EntityTypeConfiguration<CPU>
    {
        public CpuConfiguration()
        {
            Property(c => c.Socket)
                .IsRequired();
                

            Property(c => c.Model)
                .IsRequired();

            Property(c => c.CompanyID)
                .IsRequired();
        }
    }
}
