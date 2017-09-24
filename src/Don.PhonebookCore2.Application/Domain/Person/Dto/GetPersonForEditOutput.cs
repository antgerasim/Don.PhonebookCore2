using Abp.AutoMapper;

namespace Don.PhonebookCore2.Domain.Person.Dto
{
    [AutoMapFrom(typeof(Persons.Person))]
    public class GetPersonForEditOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public string EmailAddress { get; set; }
    }
}