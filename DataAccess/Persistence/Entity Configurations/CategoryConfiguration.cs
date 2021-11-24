using DataAccess.Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Persistence.Entity_Configurations
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(50);
        }
    }
}
