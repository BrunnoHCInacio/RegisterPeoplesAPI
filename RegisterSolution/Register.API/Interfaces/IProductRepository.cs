using Register.API.Models;
using Register.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Register.API.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetProductProvider(Guid productId);
        Task<IEnumerable<Product>> GetProductsProviders();
        Task<IEnumerable<Product>> GetProductsByProvider(Guid providerID);
    }
}
