using RegisterPeoples.Context;
using RegisterPeoples.Interfaces;
using RegisterPeoples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterPeoples.Repository
{
    public class PeopleRepository : Repository<People>, IPeopleRepository
    {
        public PeopleRepository(AppDbContext context) : base(context) {}

        public Task<IEnumerable<People>> GetPeoplesAddress()
        {
            throw new NotImplementedException();
        }
    }
}
