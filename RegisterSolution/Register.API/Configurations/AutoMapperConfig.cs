using AutoMapper;
using Register.API.Models;
using Register.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Register.API.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Provider, ProviderViewModel>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Address, AddressViewModel>().ReverseMap();
        }
    }
}
