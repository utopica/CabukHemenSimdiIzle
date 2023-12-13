using CabukHemenSimdiIzle.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabukHemenSimdiIzle.Domain.Entities
{
    public class Scenarist : Person
    {
       
       public ICollection<ScenaristMovie> ScenaristMovies { get; set; }

    }
}
