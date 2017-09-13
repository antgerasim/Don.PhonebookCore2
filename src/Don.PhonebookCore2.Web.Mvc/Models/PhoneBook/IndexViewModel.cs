using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Don.PhonebookCore2.Domain.Person.Dto;

namespace Don.PhonebookCore2.Web.Controllers
{
    [AutoMapFrom(typeof(ListResultDto<PersonDto>))]
    public class IndexViewModel : ListResultDto<PersonDto>
    {
        public IndexViewModel(ListResultDto<PersonDto> output)
        {
            output.MapTo(this);
        }
    }
}