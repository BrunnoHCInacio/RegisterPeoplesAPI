using RegisterPeoples.Models;
using RegisterPeoples.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterPeoples.Interfaces
{
    public interface IAddressRepository : IRepository<Address> 
    {
        Task<Address> getAddressByPeople();
    }
}
