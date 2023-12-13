using CabukHemenSimdiIzle.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabukHemenSimdiIzle.Domain.Common
{
    public class Person : EntityBase<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    

    }
}
