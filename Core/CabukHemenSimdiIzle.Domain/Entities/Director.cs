using CabukHemenSimdiIzle.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabukHemenSimdiIzle.Domain.Entities
{
    public class Director : Person
    {
        public List<Content> DirectedContents { get; set; } //?????????
    }
}
