using CabukHemenSimdiIzle.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabukHemenSimdiIzle.Domain.Dtos
{
    public class MovieAddDto
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
        public List<Guid> DirectorIds { get; set; }
        public List<Guid> ScenaristIds { get; set; }
        public List<Guid> CastIds { get; set; }
    }
}
