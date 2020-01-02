using Microsoft.EntityFrameworkCore;
using Register.API.Context;
using Register.API.Interfaces;
using Register.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Register.API.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context) {}

        public async Task<Product> GetProductProvider(Guid productId)
        {
            return await Db.Products
                .AsNoTracking()
                .Include(p=>p.Provider)
                .FirstOrDefaultAsync(p => p.Id == productId);
        }

        public async Task<IEnumerable<Product>> GetProductsByProvider(Guid providerId)
        {
            return await Buscar(p => p.ProviderId == providerId);
        }

        public async Task<IEnumerable<Product>> GetProductsProviders()
        {
            return await Db.Products
                .AsNoTracking()
                .Include(p => p.Provider)
                .ToListAsync();
        }
    }
}
