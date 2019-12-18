using RegisterPeoples.Interfaces;
using RegisterPeoples.Models;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterPeoples.Services
{
    public class PeopleService : BaseService, IPeopleService
    {
        private readonly IPeopleRepository _peopleRepository;
        private readonly IAddressRepository _addressRepository;

        public PeopleService( IPeopleRepository peopleRepository, 
                              IAddressRepository addressRepository, 
                              INotifier notifier ): base(notifier)
        {
            _peopleRepository = peopleRepository;
            _addressRepository = addressRepository;
        }

        public async Task Add(People people)
        {
            if(_peopleRepository.Buscar(p=>p.Cpf == people.Cpf).Result.Any())
            {
                Notify("Já existe um registro com este cpf");
                return;
            }
            await _addressRepository.Add(people.Address);
            await _peopleRepository.Add(people);
        }

        public void Dispose()
        {
            _peopleRepository.Dispose();
        }
    }
}
