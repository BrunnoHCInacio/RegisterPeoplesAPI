using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Register.API.Models
{
    public class Provider : Entity
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public TypeProvider TypeProvider { get; set; }
        public Address Address { get; set; }
        public bool Active { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
