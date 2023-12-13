using CabukHemenSimdiIzle.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabukHemenSimdiIzle.Persistence.Configuration
{
    public class MovieConfiguration:IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            // Primary key
            builder.HasKey(u => u.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
           
            // Title
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(70);

            //Description
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(100000);

            //PictureUrl
            builder.Property(x => x.PictureUrl).IsRequired();
            builder.Property(x => x.PictureUrl).HasMaxLength(1000);

            // ReleaseDate
            builder.Property(x => x.ReleaseDate).IsRequired();
            builder.Property(x => x.ReleaseDate).HasColumnType("smallint");

            // Language
            builder.Property(x => x.Language).IsRequired();
            builder.Property(x => x.Language).HasMaxLength(70);

            // Genre
            builder.Property(x => x.Genre).IsRequired();
            builder.Property(x => x.Genre).HasConversion<int>();

            // ImdbRating
            builder.Property(x => x.ImdbRating).IsRequired(false);
            builder.Property(x => x.ImdbRating).HasColumnType("decimal(3,1)");

            // HasBeenWatched
            builder.Property(x => x.HasBeenWatched).IsRequired();
            builder.Property(x => x.HasBeenWatched).HasDefaultValueSql("false");

            // AgeRestriction
            builder.Property(x => x.AgeRestriction).IsRequired();
            builder.Property(x => x.AgeRestriction).HasMaxLength(10);

            // Duration
            builder.Property(x => x.Duration).IsRequired();
            builder.Property(x => x.Duration).HasColumnType("int");


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

            builder.ToTable("Movies");

        }  
    }   
   
}
