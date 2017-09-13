using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;

namespace Don.PhonebookCore2.Domain.Person.Dto
{
    [AutoMapTo(typeof(Persons.Person))]
    public class CreatePersonInput
    {
        [Required]
        [MaxLength(Persons.Person.MaxNameLength)]
        public virtual string Name { get; set; }

        [Required]
        [MaxLength(Persons.Person.MaxSurnameLength)]
        public virtual string Surname { get; set; }

        [EmailAddress]
        [MaxLength(Persons.Person.MaxEmailAddressLength)]
        public virtual string EmailAddress { get; set; }
    }
}