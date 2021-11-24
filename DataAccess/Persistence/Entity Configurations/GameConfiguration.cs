using DataAccess.Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Persistence.Entity_Configurations
{
    public class GameConfiguration : EntityTypeConfiguration<Game>
    {
        public GameConfiguration()
        {
            Property(c => c.Name)
                .IsRequired();

            Property(c => c.CompanyID)
                .IsRequired();
        }

    }
}
