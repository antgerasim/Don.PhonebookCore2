using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;

using Don.PhonebookCore2.Domain.Phones;

namespace Don.PhonebookCore2.Domain.Person
{
    [AutoMapTo(typeof(Phone))]
    public class AddPhoneInput
    {
        [Range(1, int.MaxValue)]
        public int PersonId { get; set; }

        [Required]
        public PhoneType Type { get; set; }

        [Required]
        [MaxLength(Phone.MaxNumberLength)]
        public string Number { get; set; }
    }
}