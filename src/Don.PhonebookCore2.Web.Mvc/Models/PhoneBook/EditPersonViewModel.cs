using System.Collections.Generic;
using Abp.AutoMapper;
using Don.PhonebookCore2.Domain.Person.Dto;
using Don.PhonebookCore2.Domain.Phone;

namespace Don.PhonebookCore2.Web.Models.PhoneBook
{
   
    public class EditPersonViewModel
    {

        public PersonDto Person { get; set; }

        public IReadOnlyList<PhoneInPersonDto> Phones { get; set; }


  
    }
}