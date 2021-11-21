using DataAccess.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistence.Entity_Configurations
{
    public class MotherboardConfiguration : EntityTypeConfiguration<Motherboard>
    {
        public MotherboardConfiguration()
        {

            Property(m => m.Socket)
                .IsRequired();

            Property(m => m.Chipset)
                .IsRequired();

            Property(m => m.Model)
                .IsRequired();
                
            HasMany(c => c.CPUs)
                .WithRequired(m => m.Motherboard)
                .WillCascadeOnDelete(false);

            HasMany(r => r.RAMs)
                .WithRequired(m => m.Motherboard)
                .WillCascadeOnDelete(false);

            HasMany(b => b.Builds)
                .WithRequired(m => m.Motherboard)
                .WillCascadeOnDelete(false);
        }
    }
}
