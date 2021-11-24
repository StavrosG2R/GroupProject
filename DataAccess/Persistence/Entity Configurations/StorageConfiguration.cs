using DataAccess.Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Persistence.Entity_Configurations
{
    public class StorageConfiguration : EntityTypeConfiguration<Storage>
    {
        public StorageConfiguration()
        {
            Property(s => s.Model)
                .IsRequired();

            Property(s => s.StorageType)
                .IsRequired();

            Property(c => c.CompanyID)
                .IsRequired();
        }
    }
}
