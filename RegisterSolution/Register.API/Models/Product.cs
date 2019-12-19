using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Register.API.Models
{
    public class Product
    {
        public Guid ProviderId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Value { get; set; }
        public DateTime DateRegister { get; set; }
        public bool Active { get; set; }

        public Provider Provider { get; set; }
    }
}
