using DataAccess.Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Persistence.Entity_Configurations
{
    public class CompanyConfiguration : EntityTypeConfiguration<Company>
    {
        public CompanyConfiguration()
        {
            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            //! new added
            HasMany(c => c.Cases)
                .WithRequired(c => c.Company)
                .WillCascadeOnDelete(false);

            HasMany(c => c.Games)
                .WithRequired(c => c.Company)
                .WillCascadeOnDelete(false);

            HasMany(c => c.CPUs)
                .WithRequired(c => c.Company)
                .WillCascadeOnDelete(false);

            HasMany(c => c.GPUs)
                .WithRequired(c => c.Company)
                .WillCascadeOnDelete(false);

            HasMany(c => c.Motherboards)
                .WithRequired(c => c.Company)
                .WillCascadeOnDelete(false);

            HasMany(c => c.PSUs)
                .WithRequired(c => c.Company)
                .WillCascadeOnDelete(false);

            HasMany(c => c.RAMs)
                .WithRequired(c => c.Company)
                .WillCascadeOnDelete(false);

            HasMany(c => c.Storages)
                .WithRequired(c => c.Company)
                .WillCascadeOnDelete(false);
        }
    }
}
