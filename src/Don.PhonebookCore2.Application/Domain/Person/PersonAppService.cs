using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Castle.Core.Internal;
using Don.PhonebookCore2.Domain.Person.Dto;

namespace Don.PhonebookCore2.Domain.Person
{
    public class PersonAppService : PhonebookCore2AppServiceBase, IPersonAppService
    {
        private readonly IRepository<Persons.Person> _personRepository;

        public PersonAppService(IRepository<Persons.Person> personRepository)
        {
            _personRepository = personRepository;
        }

        public ListResultDto<PersonDto> GetPeople(GetPeopleInput input)
        {
            var persons = _personRepository.GetAll().WhereIf(!input.Filter.IsNullOrEmpty(),
                    p => p.Name.Contains(input.Filter) || p.Surname.Contains(input.Filter) ||
                         p.EmailAddress.Contains(input.Filter))
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Surname)
                .ToList();

            return new ListResultDto<PersonDto>(ObjectMapper.Map<List<PersonDto>>(persons));
        }

        public async Task CreatePerson(CreatePersonInput input)
        {
            var person = ObjectMapper.Map<Persons.Person>(input);

            await _personRepository.InsertAsync(person);
        }
    }
}