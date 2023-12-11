using CabukHemenSimdiIzle.Domain.Entities;
using CabukHemenSimdiIzle.Domain.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CabukHemenSimdiIzle.Domain.Common
{
    public class Content : EntityBase<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public short ReleaseDate { get; set; }
        public string Language { get; set; }
        public Guid? GenreId { get; set; }
        public Genre Genre { get; set; }
        public decimal? AverageScore { get; set; }
        public bool HasBeenWatched { get; set; }
        public string AgeRestriction { get; set; }


        public Guid? DirectorId { get; set; } // Foreign key ?????
        public Director Director { get; set; } // Navigation property ????????

       

    }
}
