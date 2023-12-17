using CabukHemenSimdiIzle.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabukHemenSimdiIzle.Application.Features.Queries.MovieQueries
{
    public class AddMovieResponse
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string? PictureUrl { get; set; }
        public short ReleaseDate { get; set; }
        public string Language { get; set; }
        public Genre Genre { get; set; }
        public decimal? ImdbRating { get; set; }   
        public string AgeRestriction { get; set; }
        public short Duration { get; set; }
    }
}
