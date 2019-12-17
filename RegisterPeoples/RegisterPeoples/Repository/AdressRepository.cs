using RegisterPeoples.Context;
using RegisterPeoples.Interfaces;
using RegisterPeoples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterPeoples.Repository
{
    public class AdressRepository : IRepository<Address>
    {
        private readonly AppDbContext _context;

        public AdressRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Address address)
        {
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
