using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabukHemenSimdiIzle.Domain.Common;

namespace CabukHemenSimdiIzle.Domain.Entities
{
    public class TvShows : Content
    {
        public Int16 DurationPerEpisode { get; set; }
        public Int16 SeasonCount { get; set; }
        public Int16 EpisodeCount { get; set; }
    }
}
