using DataAccess.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistence.Entity_Configurations
{
    public class RamConfiguration : EntityTypeConfiguration<RAM>
    {
        public RamConfiguration()
        {
            Property(r => r.Model)
              .IsRequired();

            HasRequired(r => r.Motherboard)
                .WithMany(m => m.RAMs)
                .HasForeignKey(r => r.MotherboardId)
                .WillCascadeOnDelete(false);
        }
    }
}
