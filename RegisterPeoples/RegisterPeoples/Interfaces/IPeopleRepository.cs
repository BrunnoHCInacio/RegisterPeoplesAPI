using RegisterPeoples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterPeoples.Interfaces
{
    interface IPeopleRepository
    {
        Task<IEnumerable<People>> GetPeoplesAddress();
    }
}
