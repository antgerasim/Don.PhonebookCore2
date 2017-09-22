using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Don.PhonebookCore2.Domain.Person.Dto;
using Don.PhonebookCore2.Domain.Phone;

namespace Don.PhonebookCore2.Domain.Person
{
    public interface IPersonAppService : IApplicationService
    {
        ListResultDto<PersonDto> GetPeople(GetPeopleInput input);
        Task CreatePerson(CreatePersonInput input);
        //We could create a new, seperated IPhoneAppService.It's your choice. But, we can consider Person as an aggregate and add phone related methods here. AddPhoneInput DTO is shown below:

        Task DeletePhone(EntityDto<long> input);
        Task<PhoneInPersonDto> AddPhone(AddPhoneInput input);
      
    }
}