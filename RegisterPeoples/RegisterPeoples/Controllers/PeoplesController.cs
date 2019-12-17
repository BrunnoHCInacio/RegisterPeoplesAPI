using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RegisterPeoples.Models;

namespace RegisterPeoples.Controllers
{
    [Route("api/[controller]")]
    public class PeoplesController : MainController
    {
        private readonly AddressRe
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetAll()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id:guid}")]
        public ActionResult<People> GetById(Guid id)
        {
            return ;
        }

        // POST api/values
        [HttpPost]
        public void Add(string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id:guid}")]
        public void Update(Guid id, string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id:guid}")]
        public void Delete(Guid id)
        {
        }
    }
}
