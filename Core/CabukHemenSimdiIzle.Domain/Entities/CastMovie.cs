using CabukHemenSimdiIzle.Domain.Common;
using CabukHemenSimdiIzle.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabukHemenSimdiIzle.Domain.Entities
{
    public class CastMovie: ICreatedByEntity
    {
        public Guid CastId { get; set; }
        public Cast Cast { get; set; }
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}
