using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Don.PhonebookCore2.Domain.Phones;

namespace Don.PhonebookCore2.Domain.Phone
{
   
    [AutoMapTo(typeof(Phones.Phone))]
    public class AddPhoneInput
    {
        [Range(1, int.MaxValue)]
        public int PersonId { get; set; }

        [Required]
        public PhoneType Type { get; set; }

        [Required]
        [MaxLength(Phones.Phone.MaxNumberLength)]
        public string Number { get; set; }
    }
}