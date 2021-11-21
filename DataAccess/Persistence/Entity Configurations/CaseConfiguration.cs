using DataAccess.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            HasRequired(c => c.Motherboard)
                .WithMany(m => m.Cases)
                .HasForeignKey(c => c.MotherboardId)
                .WillCascadeOnDelete(false);

            HasMany(c => c.Builds)
                .WithRequired(b => b.Case)
                .HasForeignKey(c => c.CaseId)
                .WillCascadeOnDelete(false);
        }
    }
}
