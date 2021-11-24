using DataAccess.Core.Entities;
using System.Data.Entity.ModelConfiguration;

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

            Property(c => c.CompanyID)
                .IsRequired();
        }
    }
}
