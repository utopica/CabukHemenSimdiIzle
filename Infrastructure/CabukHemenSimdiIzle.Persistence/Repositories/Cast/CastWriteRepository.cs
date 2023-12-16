using CabukHemenSimdiIzle.Application.Repositories;
using CabukHemenSimdiIzle.Domain.Entities;
using CabukHemenSimdiIzle.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabukHemenSimdiIzle.Persistence.Repositories
{
    public class CastWriteRepository : WriteRepository<Cast>, ICastWriteRepository
    {
        public CastWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
