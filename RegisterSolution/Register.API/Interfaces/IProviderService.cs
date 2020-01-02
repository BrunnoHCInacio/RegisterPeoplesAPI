using Register.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Register.API.Interfaces
{
    public interface IProviderService
    {
        Task Add(Provider provider);
        Task Update(Provider provider);
        Task UpdateAddress(Address address);
        Task Delete(Guid id);
    }
}
