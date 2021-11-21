using DataAccess.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


            HasMany(c => c.Builds)
                .WithRequired(b => b.CPU)
                .HasForeignKey(c => c.CPUId)
                .WillCascadeOnDelete(false);

        }
    }
}
