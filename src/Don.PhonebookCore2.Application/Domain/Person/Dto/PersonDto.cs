using System.Collections.ObjectModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Don.PhonebookCore2.Domain.Phones;

namespace Don.PhonebookCore2.Domain.Person.Dto
{
    [AutoMapFrom(typeof(Persons.Person))]//mapping from Person to PersonDto
    public class PersonDto: EntityDto<int>
    {
        public  string Name { get; set; }
        public  string Surname { get; set; }
        public  string EmailAddress { get; set; }
        public Collection<Phone> Phones { get; set; }
    }

    [AutoMapFrom(typeof(Phone))]
    public class PhoneInPersonDto : CreationAuditedEntityDto<long>
    {
        public PhoneType Type { get; set; }
        public string Number { get; set; }
    }
}