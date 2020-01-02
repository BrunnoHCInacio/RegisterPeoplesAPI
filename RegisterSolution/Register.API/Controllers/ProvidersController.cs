using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Register.API.Extensions;
using Register.API.Interfaces;
using Register.API.Models;
using Register.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Register.API.Controllers
{
    [Authorize]
    [Route("api/providers")]
    public class ProvidersController : MainController
    {
        private readonly IProviderRepository _providerRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IProviderService _providerService;
        private readonly IMapper _mapper;

        public ProvidersController(IProviderRepository providerRepository,
                                    IMapper mapper,
                                    INotifier notifier,
                                    IProviderService providerService, 
                                    IAddressRepository addressRepository, 
                                    IUser appUser) : base(notifier, appUser)
        {
            _providerRepository = providerRepository;
            _mapper = mapper;
            _providerService = providerService;
            _addressRepository = addressRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<ProviderViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<ProviderViewModel>>(await _providerRepository.GetAll());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProviderViewModel>> GetById(Guid id)
        {
            var provider = await GetProviderProductsAddresses(id);
            if (provider == null) 
            {
                Notify("Fornecedor não encontrado");
                return CustomResponse();
            }
            return _mapper.Map<ProviderViewModel>(provider);
        }

        [HttpGet("obter-endereco{id:guid}")]
        public async Task<AddressViewModel> getAddressByID(Guid id)
        {
            return _mapper.Map<AddressViewModel>(await _addressRepository.GetById(id));
        }

        [HttpPut("atualizar-endereco/{id:guid}")]
        public async Task<ActionResult<AddressViewModel>> UpdateAddress(Guid id, AddressViewModel addressViewModel)
        {
            if(id != addressViewModel.Id)
            {
                Notify("O id fornecido não pode ser diferente do id cadastrado");
                return CustomResponse();
            }
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _providerService.UpdateAddress(_mapper.Map<Address>(addressViewModel));
            return CustomResponse(addressViewModel);
        }

        [ClaimsAuthorize("Provider","Add")]
        [HttpPost]
        public async Task<ActionResult> Add(ProviderViewModel providerViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _providerService.Add(_mapper.Map<Provider>(providerViewModel));
            return CustomResponse(providerViewModel);
        }

        [ClaimsAuthorize("Provider", "Update")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(Guid id, ProviderViewModel providerViewModel)
        {
            if(id != providerViewModel.Id)
            {
                Notify("O id informado não pode ser diferente do id cadastrado");
                return CustomResponse();
            }
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _providerService.Update(_mapper.Map<Provider>(providerViewModel));
            return CustomResponse(providerViewModel);
        }

        [ClaimsAuthorize("Provider", "Delete")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id) 
        {
            var provider = await _providerRepository.GetById(id);
            if (provider == null) return NotFound();
        
            await _providerService.Delete(id);
            return CustomResponse();
        }

        private async Task<Provider> GetProviderProductsAddresses(Guid ProviderId)
        {
            return  await _providerRepository.GetProviderAddressProducts(ProviderId);
        }

    }

}
