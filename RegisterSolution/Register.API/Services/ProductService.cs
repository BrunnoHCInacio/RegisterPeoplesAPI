using Register.API.Interfaces;
using Register.API.Models;
using Register.API.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Register.API.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository,
                                INotifier notifier) : base(notifier)
        {
            _productRepository = productRepository;
        }

        public async Task Add(Product product)
        {
            if (!RunValidation(new ProductValidation(), product)) return;
            await _productRepository.Add(product);
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Product product)
        {
            if (!RunValidation(new ProductValidation(), product)) return;
            await _productRepository.Update(product);
        }
    }
}
