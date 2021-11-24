using DataAccess.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistence.Entity_Configurations
{
    public class CommentConfiguration : EntityTypeConfiguration<Comment>
    {
        public CommentConfiguration()
        {
            Property(c => c.Text)
                .IsRequired()
                .HasMaxLength(256);

            Property(c => c.CommentOwnerID)
                .IsRequired();

            HasRequired(b => b.Build)
                .WithMany(c => c.Comments)
                .HasForeignKey(b => b.BuildID);
        }
    }
}
