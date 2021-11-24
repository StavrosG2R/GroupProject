using DataAccess.Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Persistence.Entity_Configurations
{
    public class CaseConfiguration : EntityTypeConfiguration<Case>
    {
        public CaseConfiguration()
        {
            Property(c => c.Model)
                .IsRequired();

            Property(c => c.Size)
                .IsRequired();

            Property(c => c.CompanyID)
                .IsRequired();
        }
    }
}
