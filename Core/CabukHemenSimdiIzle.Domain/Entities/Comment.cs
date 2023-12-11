using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabukHemenSimdiIzle.Domain.Entities
{
    public class Comment
    {
        public Guid UserId { get; set; }
        public string Description { get; set; }

        public Guid ContentId { get; set; } // ???????
    }
}
