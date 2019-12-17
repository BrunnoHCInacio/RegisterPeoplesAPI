using RegisterPeoples.Interfaces;
using RegisterPeoples.Models;
using RegisterPeoples.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterPeoples.Services
{
    public class AddressService : IService<Address>
    {
        private readonly AdressRepository _repository;

        public AddressService(AdressRepository repository)
        {
            _repository = repository;
        }

        public async Task Add(Address address)
        {
            address.Id = Guid.NewGuid();
            await _repository.Add(address);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
