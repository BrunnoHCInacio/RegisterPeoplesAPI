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
    public class ProviderRepository : Repository<Provider>, IProviderRepository
    {
        public ProviderRepository(AppDbContext context) : base(context) {}

        public async Task<Provider> GetProviderAddress(Guid id)
        {
            return await Db.Providers
                .AsNoTracking()
                .Include(p => p.Address)
                .FirstOrDefaultAsync(p=>p.Id == id);
        }

        public async Task<Provider> GetProviderAddressProducts(Guid id)
        {
            return await Db.Providers
                .AsNoTracking()
                .Include(p => p.Address)
                .Include(p => p.Products)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
