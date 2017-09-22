using Abp.Localization;
using Don.PhonebookCore2.Domain.Person.Dto;
using Don.PhonebookCore2.Domain.Phone;

namespace Don.PhonebookCore2.Web.Models.PhoneBook
{
    public class PhoneRowInPersonListViewModel
    {
        public PhoneInPersonDto Phone { get; set; }

        public PhoneRowInPersonListViewModel(PhoneInPersonDto phone)
        {
            Phone = phone;
        }

        public string GetPhoneTypeAsString()
        {
            return LocalizationHelper.GetString(PhonebookCore2Consts.LocalizationSourceName, "PhoneType_" + Phone.Type);
        }
    }
}