using RegisterPeoples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RegisterPeoples.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Add(TEntity entity);

        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);

        Task<int> SaveChanges();
    }
}
