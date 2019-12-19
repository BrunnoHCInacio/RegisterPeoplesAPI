using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Register.API.Interfaces;
using Register.API.Models;
using Register.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Register.API.Controllers
{
    [Route("api/providers")]
    public class ProvidersController : MainController
    {
        private readonly IProviderRepository _providerRepository;
        private readonly IMapper _mapper;

        public ProvidersController(IProviderRepository providerRepository, 
                                    IMapper mapper, 
                                    INotifier notifier):base(notifier)
        {
            _providerRepository = providerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProviderViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<ProviderViewModel>>(await _providerRepository.GetAll());
        }
    }

}
