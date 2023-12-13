using CabukHemenSimdiIzle.Domain.Common;
using CabukHemenSimdiIzle.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabukHemenSimdiIzle.Domain.Entities
{
    public class Comment:EntityBase<Guid>
    {
        
        public string Description { get; set; }
        public Movie Movie { get; set; }
        public Guid MovieId { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
   
    }
}
