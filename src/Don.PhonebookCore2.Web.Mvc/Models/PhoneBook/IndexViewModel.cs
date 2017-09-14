using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Don.PhonebookCore2.Domain.Person.Dto;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;

namespace Don.PhonebookCore2.Web.Models.PhoneBook
{
    [AutoMapFrom(typeof(ListResultDto<PersonDto>))]//map from ListResultDto<PersonDto> to IndexViewModel
    public class IndexViewModel : ListResultDto<PersonDto>
    {
        public string Filter { get; set; }

        public IndexViewModel(ListResultDto<PersonDto> output, string filter = null)
        {
            output.MapTo(this);
            Filter = filter;
        }
    }
}