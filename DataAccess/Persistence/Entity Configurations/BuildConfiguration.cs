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
        }
    }
}
