using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Register.API.Extensions
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public double ExpirationHours { get; set; }
        public string Emitter { get; set; }
        public string ValidOn { get; set; }
    }
}
