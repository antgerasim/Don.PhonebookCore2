using Abp.AutoMapper;
using Don.PhonebookCore2.Domain.Person.Dto;

namespace Don.PhonebookCore2.Web.Models.PhoneBook
{
    [AutoMapFrom(typeof(PersonDto))]
    public class EditPersonModalViewModel : PersonDto
    {
        public EditPersonModalViewModel(PersonDto person)
        {
            person.MapTo(this);
        }
    }
}