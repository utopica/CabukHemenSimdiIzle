using CabukHemenSimdiIzle.Application.Repositories;
using CabukHemenSimdiIzle.Domain.Common;
using CabukHemenSimdiIzle.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabukHemenSimdiIzle.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityBase<Guid>
    {
        protected readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;

            Table = _context.Set<T>();
        }

        public DbSet<T> Table { get; }
    }
}
