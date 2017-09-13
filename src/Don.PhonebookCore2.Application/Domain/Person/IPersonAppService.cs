using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Don.PhonebookCore2.Domain.Person.Dto;

namespace Don.PhonebookCore2.Domain.Person
{
    public interface IPersonAppService : IApplicationService
    {
        ListResultDto<PersonDto> GetPeople(GetPeopleInput input);

        Task CreatePerson(CreatePersonInput input);
    }
}