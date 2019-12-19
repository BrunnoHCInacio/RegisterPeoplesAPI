using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Register.API.Interfaces
{
    public interface IRepository<TEntity> : IDisposable
    {
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Remove(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(Guid id);
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
    }
}
