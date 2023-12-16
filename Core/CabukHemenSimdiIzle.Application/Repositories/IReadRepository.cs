using CabukHemenSimdiIzle.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CabukHemenSimdiIzle.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : EntityBase<Guid>
    {
        IQueryable<T> GetAll();

        IQueryable<T> GetWhere(Expression<Func<T, bool>> method);

        Task<T> GetSingleAsync(Expression<Func<T, bool>> method);  

        Task<T> GetByIdAsync(string id);

        
    }
}
