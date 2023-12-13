using CabukHemenSimdiIzle.Domain.Common;
using CabukHemenSimdiIzle.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabukHemenSimdiIzle.Domain.Entities
{
    public class ScenaristMovie : ICreatedByEntity
    {
        public Guid ScenaristId { get; set; }
        public Scenarist Scenarist { get; set; }
        public Guid MovieID { get; set; }
        public Movie Movie { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}
