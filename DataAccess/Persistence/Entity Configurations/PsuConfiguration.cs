using DataAccess.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            HasMany(p => p.Builds)
                .WithRequired()
                .WillCascadeOnDelete(false);
        }
    }
}
