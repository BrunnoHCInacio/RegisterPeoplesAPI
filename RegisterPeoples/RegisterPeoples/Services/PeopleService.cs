using RegisterPeoples.Interfaces;
using RegisterPeoples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterPeoples.Services
{
    public class PeopleService : IService<People>
    {

        private readonly AddressService _addressService;

        public PeopleService(AddressService addressService)
        {
            _addressService = addressService;
        }

        public async Task Add(People people)
        {

            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
