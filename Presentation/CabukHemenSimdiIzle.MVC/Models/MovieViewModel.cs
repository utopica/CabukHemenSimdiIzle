using CabukHemenSimdiIzle.Domain.Enums;

namespace CabukHemenSimdiIzle.MVC.Models
{
    public class MovieViewModel
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
        public string CreatedByUserId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
