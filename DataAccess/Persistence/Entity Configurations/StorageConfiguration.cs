using DataAccess.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            HasMany(s => s.Builds)
                .WithRequired()
                .WillCascadeOnDelete(false);
        }
    }
}
