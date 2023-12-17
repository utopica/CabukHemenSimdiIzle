using CabukHemenSimdiIzle.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabukHemenSimdiIzle.Persistence.Configuration
{
    public class ScenaristMovieConfiguration : IEntityTypeConfiguration<ScenaristMovie>
    {
        public void Configure(EntityTypeBuilder<ScenaristMovie> builder)
        {
      
            builder.HasKey(x => new { x.ScenaristId, x.MovieId });


            //Relationships
            builder.HasOne(x => x.Scenarist)
                .WithMany(x => x.ScenaristMovies)
                .HasForeignKey(x => x.ScenaristId);

            builder.HasOne(x => x.Movie)
                .WithMany(x => x.ScenaristMovies)
                .HasForeignKey(x => x.MovieId);

            // CreatedByUserId
            builder.Property(x => x.CreatedByUserId).IsRequired();
            builder.Property(x => x.CreatedByUserId).HasMaxLength(75);

            // CreatedOn
            builder.Property(x => x.CreatedOn).IsRequired();

            builder.ToTable("ScenaristMovies");
        }
    }
}
