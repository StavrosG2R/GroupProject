using DataAccess.Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Persistence.Entity_Configurations
{
    public class PsuConfiguration : EntityTypeConfiguration<PSU>
    {
        public PsuConfiguration()
        {
            Property(p => p.Modularity)
                .IsRequired();

            Property(p => p.Efficiency)
                .IsRequired();

            Property(p => p.Model)
                .IsRequired();

            Property(c => c.CompanyID)
                .IsRequired();
        }
    }
}
