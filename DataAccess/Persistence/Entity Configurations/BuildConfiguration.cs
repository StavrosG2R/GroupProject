using DataAccess.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistence.Entity_Configurations
{
    public class BuildConfiguration : EntityTypeConfiguration<Build>
    {
        public BuildConfiguration()
        {
            Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(100);

            HasRequired(b => b.Motherboard)
                .WithMany(m => m.Builds)
                .HasForeignKey(b => b.MotherboardId)
                .WillCascadeOnDelete(false);

            HasRequired(b => b.PSU)
                .WithMany(p => p.Builds)
                .HasForeignKey(b => b.PSUId)
                .WillCascadeOnDelete(false);

            HasRequired(b => b.RAM)
                .WithMany(r => r.Builds)
                .HasForeignKey(b => b.RAMId)
                .WillCascadeOnDelete(false);

            HasRequired(b => b.Storage)
                .WithMany(s => s.Builds)
                .HasForeignKey(b => b.StorageId)
                .WillCascadeOnDelete(false);

            HasRequired(b => b.Case)
                .WithMany(c => c.Builds)
                .HasForeignKey(b => b.CaseId)
                .WillCascadeOnDelete(false);

            HasRequired(b => b.CPU)
                .WithMany(c => c.Builds)
                .HasForeignKey(b => b.CPUId)
                .WillCascadeOnDelete(false);

            HasMany(b => b.Comments)
                .WithRequired(c => c.Build)
                .HasForeignKey(b => b.BuildId)
                .WillCascadeOnDelete(false);

            HasRequired(b => b.Category)
                .WithMany(c => c.Builds)
                .HasForeignKey(b => b.CategoryID)
                .WillCascadeOnDelete(false);

                
        }
    }
}
