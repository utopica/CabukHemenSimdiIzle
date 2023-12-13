using CabukHemenSimdiIzle.Domain.Entities;
using CabukHemenSimdiIzle.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabukHemenSimdiIzle.Persistence.Configuration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    { 
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            // ID - Primary Key
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            //Description
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(100000);

            // COMMON FIELDS

            // CreatedByUserId
            builder.Property(x => x.CreatedByUserId).IsRequired();
            builder.Property(x => x.CreatedByUserId).HasMaxLength(75);

            // CreatedOn
            builder.Property(x => x.CreatedOn).IsRequired();

            // ModifiedByUserId
            builder.Property(x => x.ModifiedByUserId).IsRequired(false);
            builder.Property(x => x.ModifiedByUserId).HasMaxLength(75);

            // LastModifiedOn
            builder.Property(x => x.LastModifiedOn).IsRequired(false);

            // DeletedByUserId
            builder.Property(x => x.DeletedByUserId).IsRequired(false);
            builder.Property(x => x.DeletedByUserId).HasMaxLength(75);

            // DeletedOn
            builder.Property(x => x.DeletedOn).IsRequired(false);

            // IsDeleted
            builder.Property(x => x.IsDeleted).IsRequired();

            //Relationships
            builder.HasOne<Movie>(m => m.Movie)
                .WithMany(c => c.Comments)
                .HasForeignKey(m => m.MovieId);
           
            builder.HasOne<User>(m => m.User)
                .WithMany(c => c.Comments)
                .HasForeignKey(m => m.UserId);


            builder.ToTable("Comments");


        }
    }
}
