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

        //? Ta nav props na mhn einai required,
        //? na einai ta foreign keys tous
        public BuildConfiguration()
        {
            Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(100);

            Property(b => b.BuilderID)
                .IsRequired();

            Property(b => b.MotherboardID)
                .IsRequired();

            Property(b => b.PSUID)
                .IsRequired();

            Property(b => b.RAMID)
                .IsRequired();

            Property(b => b.StorageID)
                .IsRequired();

            Property(b => b.CaseID)
                .IsRequired();

            Property(b => b.CPUID)
                .IsRequired();

            Property(b => b.CategoryID)
                .IsRequired();
        }
    }
}
