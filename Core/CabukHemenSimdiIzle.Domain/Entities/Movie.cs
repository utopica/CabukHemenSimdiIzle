using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabukHemenSimdiIzle.Domain.Common;
using CabukHemenSimdiIzle.Domain.Enums;

namespace CabukHemenSimdiIzle.Domain.Entities
{
    public class Movie : EntityBase<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string? PictureUrl { get; set; }
        public short ReleaseDate { get; set; } //int16 -> short
        public string Language { get; set; }
        public Genre Genre { get; set; }
        public decimal? ImdbRating { get; set; }
        public bool? HasBeenWatched { get; set; }
        public string AgeRestriction { get; set; }

        public short Duration { get; set; } //int32 -> short

        public ICollection<CastMovie> CastMovies { get; set; }
        public ICollection<DirectorMovie> DirectorMovies { get; set; }
        public ICollection<ScenaristMovie> ScenaristMovies { get; set; }
        public ICollection<Comment> Comments { get; set; }

        // public Guid CommentId { get; set; }          
        //public Guid DirectorId { get; set; }

    }
}
