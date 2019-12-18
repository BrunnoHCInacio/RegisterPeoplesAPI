using RegisterPeoples.Context;
using RegisterPeoples.Interfaces;
using RegisterPeoples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterPeoples.Repository
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(AppDbContext context) : base(context) {}

        public Task<Address> getAddressByPeople()
        {
            throw new NotImplementedException();
        }
    }
}
