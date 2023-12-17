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
    public class DirectorMovieConfiguration : IEntityTypeConfiguration<DirectorMovie>
    {
        public void Configure(EntityTypeBuilder<DirectorMovie> builder)
        {
            builder.HasKey(x => new { x.DirectorId, x.MovieId });
           

            //Relationships
            builder.HasOne(x => x.Director)
                .WithMany(x => x.DirectorMovies)
                .HasForeignKey(x => x.DirectorId);

            builder.HasOne(x => x.Movie)
                .WithMany(x => x.DirectorMovies)
                .HasForeignKey(x => x.MovieId);

            // CreatedByUserId
            builder.Property(x => x.CreatedByUserId).IsRequired();
            builder.Property(x => x.CreatedByUserId).HasMaxLength(75);

            // CreatedOn
            builder.Property(x => x.CreatedOn).IsRequired();

            builder.ToTable("DirectorMovies");
        }
    }
}
