using Abp.AutoMapper;

namespace Don.PhonebookCore2.Domain.Person.Dto
{
    [AutoMapFrom(typeof(Persons.Person))]//mapping from Person to PersonDto
    public class PersonDto
    {
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string EmailAddress { get; set; }
    }
}