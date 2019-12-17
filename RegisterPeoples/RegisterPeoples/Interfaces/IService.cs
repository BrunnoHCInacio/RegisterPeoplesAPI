using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterPeoples.Interfaces
{
    interface IService<TEntity> : IDisposable
    {
        Task Add(TEntity entity);
    }
}
