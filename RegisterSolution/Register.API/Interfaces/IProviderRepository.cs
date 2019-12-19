using Register.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Register.API.Interfaces
{
    public interface IProviderRepository : IRepository<Provider>
    {
        Task<Provider> GetProviderAddress(Guid id);
        Task<Provider> GetProviderAddressProducts(Guid id);
    }
}
