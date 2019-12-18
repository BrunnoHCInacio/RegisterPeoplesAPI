using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RegisterPeoples.Interfaces;
using RegisterPeoples.Models;

namespace RegisterPeoples.Controllers
{
    [Route("api/peoples")]
    public class PeoplesController : MainController
    {
        private readonly IPeopleRepository _peopleRepository;
        private readonly IPeopleService _peopleService;

        public PeoplesController(IPeopleRepository peopleRepository, 
                                 IPeopleService peopleService,
                                 INotifier notifier ) : base(notifier)
        {
            _peopleRepository = peopleRepository;
            _peopleService = peopleService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetAll()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id:guid}")]
        public void GetById(Guid id)
        {
            
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Add(People people)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _peopleService.Add(people);

            return CustomResponse(people);
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
