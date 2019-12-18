using RegisterPeoples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterPeoples.Interfaces
{
    public interface IPeopleService : IDisposable
    {
        Task Add(People people);
    }
}
