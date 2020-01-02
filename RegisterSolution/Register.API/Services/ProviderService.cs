using Register.API.Interfaces;
using Register.API.Models;
using Register.API.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Register.API.Services
{
    public class ProviderService : BaseService, IProviderService
    {
        private readonly IProviderRepository _providerRepository;
        private readonly IAddressRepository _addressRepository;

        public ProviderService(IProviderRepository providerRepository,
                                INotifier notifier, 
                                IAddressRepository addressRepository) : base(notifier)
        {
            _providerRepository = providerRepository;
            _addressRepository = addressRepository;
        }

        public async Task Add(Provider provider)
        {
           if(!RunValidation(new ProviderVatidation(), provider)
                || !RunValidation(new AddressValidation(), provider.Address)) return;

           if(_providerRepository.Buscar(p=>p.Document == provider.Document).Result.Any())
            {
                Notify("Já existem um fornecedor com este documento registrado");
                return;
            }
            await _providerRepository.Add(provider);
        }

        public async Task Update(Provider provider)
        {
            if (!RunValidation(new ProviderVatidation(), provider)) return;

            if (_providerRepository
                    .Buscar(p => p.Document == provider.Document
                            && p.Id != provider.Id)
                    .Result
                    .Any())
            {
                Notify("Já existem um fornecedor com este documento registrado");
                return;
            }
            await _providerRepository.Update(provider);
        }

        public async Task UpdateAddress(Address address)
        {
            if (!RunValidation(new AddressValidation(), address)) return;

            await _addressRepository.Update(address);
        }

        public async Task Delete(Guid id)
        {
            if (_providerRepository.GetProviderAddressProducts(id).Result.Products.Any())
            {
                Notify("Este fornecedor possui produtos cadastrados.");
                return;
            }
            var address = await _addressRepository.GetAddressByProvider(id);
            if(address != null)
            {
                await _addressRepository.Remove(address.Id);
            }
            await _providerRepository.Remove(id);
        }

       
    }
}
