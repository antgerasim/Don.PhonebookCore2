using Don.PhonebookCore2.Domain.Person.Dto;

namespace Don.PhonebookCore2.Web.Models.PhoneBook
{
    public class EditPersonViewModel
    {
        public int Id { get; set; }
  
        public string Name { get; set; }

        public string Surname { get; set; }

        public string EmailAddress { get; set; }

        public EditPersonViewModel(GetPersonForEditOutput personForEdit)
        {
            Id = personForEdit.Id;
            Name = personForEdit.Name;
            Surname = personForEdit.Surname;
            EmailAddress = personForEdit.EmailAddress;
        }
    }
}