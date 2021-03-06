using System.Collections.Generic;
using System.Collections.ObjectModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Don.PhonebookCore2.Domain.Phone;
using Don.PhonebookCore2.Domain.Phones;

namespace Don.PhonebookCore2.Domain.Person.Dto
{
    [AutoMapFrom(typeof(Persons.Person))]//mapping from Person to PersonDto
    public class PersonDto: EntityDto<int>
    {
        //todo add required
        public  string Name { get; set; }
        public  string Surname { get; set; }
        public  string EmailAddress { get; set; }
        public List<PhoneInPersonDto> Phones { get; set; }
    }
}