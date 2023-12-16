﻿using CabukHemenSimdiIzle.Application.Repositories;
using CabukHemenSimdiIzle.Domain.Common;
using CabukHemenSimdiIzle.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CabukHemenSimdiIzle.Persistence.Repositories
{
    public class ReadRepository<T> : Repository<T>, IReadRepository<T> where T : EntityBase<Guid>
    {
        public ReadRepository(AppDbContext context) : base(context)
        {
        }

        public IQueryable<T> GetAll() => Table;

        public async Task<T> GetByIdAsync(string id)
           =>  await Table.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
        

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
            => await Table.FirstOrDefaultAsync(method);

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
            => Table.Where(method);
    }

}
