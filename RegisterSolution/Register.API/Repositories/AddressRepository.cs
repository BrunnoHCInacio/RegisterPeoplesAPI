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
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(AppDbContext context) : base(context) {}
        public Task<Address> GetAddressByProvider(Guid providerId)
        {
            return Db.Addresses.AsNoTracking().FirstOrDefaultAsync(a => a.ProviderId == providerId);
        }
    }
}
