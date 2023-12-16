using CabukHemenSimdiIzle.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabukHemenSimdiIzle.Application.Repositories
{
    public interface IRepository<T> where T : EntityBase<Guid>
    {
        DbSet<T> Table { get; }

        
    }
}
