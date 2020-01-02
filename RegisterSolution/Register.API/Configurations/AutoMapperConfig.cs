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
            CreateMap<Product, ProductViewModel>()
                .ForMember(dest =>dest.ProviderName, 
                           option => option.MapFrom(src => src.Provider.Name));
            CreateMap<ProductViewModel, Product>();
            CreateMap<ProductImageViewModel, Product>().ReverseMap();
            CreateMap<Address, AddressViewModel>().ReverseMap();
        }
    }
}
