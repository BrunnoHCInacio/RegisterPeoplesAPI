using RegisterPeoples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterPeoples.Interfaces
{
    interface IRepository<TEntity> : IDisposable
    {
        Task Add(TEntity entity);

        Task<int> SaveChanges();
    }
}
