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
    public class CastMovieConfiguration : IEntityTypeConfiguration<CastMovie>
    {
        public void Configure(EntityTypeBuilder<CastMovie> builder)
        {
            builder.HasKey(x => new { x.CastId, x.MovieId });


            //Relationships
            builder.HasOne<Cast>(c => c.Cast)
                .WithMany(cm => cm.CastMovies)
                .HasForeignKey(c => c.CastId);

            builder.HasOne<Movie>(m => m.Movie)
                .WithMany(cm => cm.CastMovies)
                .HasForeignKey(m => m.MovieId);


            // CreatedByUserId
            builder.Property(x => x.CreatedByUserId).IsRequired();
            builder.Property(x => x.CreatedByUserId).HasMaxLength(75);

            // CreatedOn
            builder.Property(x => x.CreatedOn).IsRequired();

            builder.ToTable("CastMovies");
        }
    }
}
