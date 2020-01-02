using Register.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Register.API.Interfaces
{
    public interface IProductService
    {
        Task Add(Product product);
        Task Update(Product product);
        Task Remove(Guid id);
    }
}
