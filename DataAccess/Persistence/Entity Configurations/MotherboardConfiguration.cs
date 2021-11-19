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
            Property(c => c.Socket)
                .IsRequired();

            Property(c => c.Chipset)
                .IsRequired();

            Property(c => c.Model)
                .IsRequired();

            Property(c => c.Chipset)
                .IsRequired();
        }
    }
}
