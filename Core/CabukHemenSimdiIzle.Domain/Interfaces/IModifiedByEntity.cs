using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabukHemenSimdiIzle.Domain.Interfaces
{
    public interface IModifiedByEntity
    {
        public string? ModifiedByUserId { get; set; }
        public DateTimeOffset? LastModifiedOn { get; set; }
    }
}
