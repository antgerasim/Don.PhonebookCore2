using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace Don.PhonebookCore2.Domain.Person
{
    public class EditPersonInput : IEntityDto
    {
        [Required]
        [MaxLength(Persons.Person.MaxNameLength)]
        public virtual string Name { get; set; }


        [Required]
        [MaxLength(Persons.Person.MaxSurnameLength)]
        public virtual string Surname { get; set; }

        [MaxLength(Persons.Person.MaxEmailAddressLength)]
        public virtual string EmailAddress { get; set; }

        public int Id { get; set; }
    }
}