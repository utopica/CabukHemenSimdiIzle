using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabukHemenSimdiIzle.Domain.Common;

namespace CabukHemenSimdiIzle.Domain.Entities
{
    public class Movie : Content
    {
        public Int16 Duration { get; set; }

    }
}
