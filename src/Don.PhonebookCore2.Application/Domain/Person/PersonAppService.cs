using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Castle.Core.Internal;
using Don.PhonebookCore2.Authorization;
using Don.PhonebookCore2.Domain.Person.Dto;
using Don.PhonebookCore2.Domain.Phones;
using Microsoft.EntityFrameworkCore;

namespace Don.PhonebookCore2.Domain.Person
{
    [AbpAuthorize(PermissionNames.Pages_Tenant_PhoneBook)]//must be logged as tenant, not as host
    public class PersonAppService : PhonebookCore2AppServiceBase, IPersonAppService
    {
        private readonly IRepository<Persons.Person> _personRepository;
        private readonly IRepository<Phones.Phone, long> _phoneRepository;

        public PersonAppService(IRepository<Persons.Person> personRepository, IRepository<Phones.Phone,long> phoneRepository)
        {
            _personRepository = personRepository;
            _phoneRepository = phoneRepository;
        }

        public ListResultDto<PersonDto> GetPeople(GetPeopleInput input)
        {
            var persons = _personRepository
                .GetAll()
                .Include(p=>p.Phones)
                .WhereIf(!input.Filter.IsNullOrEmpty(),
                    p => p.Name.Contains(input.Filter) || p.Surname.Contains(input.Filter) ||
                         p.EmailAddress.Contains(input.Filter))
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Surname)
                .ToList();

            return new ListResultDto<PersonDto>(ObjectMapper.Map<List<PersonDto>>(persons));
        }

        [AbpAuthorize(PermissionNames.Pages_Tenant_PhoneBook_CreatePerson)]
        public async Task CreatePerson(CreatePersonInput input)
        {
            var person = ObjectMapper.Map<Persons.Person>(input);

            await _personRepository.InsertAsync(person);
        }

        [AbpAuthorize(PermissionNames.Pages_Tenant_PhoneBook_DeletePerson)]
        public async Task DeletePerson(EntityDto input)
        {
            await _personRepository.DeleteAsync(input.Id);
        }

        public async Task DeletePhone(EntityDto<long> input)
        {
            await _phoneRepository.DeleteAsync(input.Id);
        }

        public async Task<PhoneInPersonDto> AddPhone(AddPhoneInput input)
        {
            var person = _personRepository.Get(input.PersonId);
            await _personRepository.EnsureCollectionLoadedAsync(person, p => p.Phones);

            var phone = ObjectMapper.Map<Phone>(input);
            person.Phones.Add(phone);
            /*(Notice that; normally it's not needed to call CurrentUnitOfWork.SaveChangesAsync. It's automatically called at the end of the method. 
             * We called it in the method since we need to save entity and get it's Id immediately*/
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<PhoneInPersonDto>(phone);
            //weiter mit https://www.aspnetzero.com/Documents/Developing-Step-By-Step-Core/#view
        }

    }
}