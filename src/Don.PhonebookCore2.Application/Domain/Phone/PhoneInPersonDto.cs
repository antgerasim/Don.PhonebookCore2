using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Don.PhonebookCore2.Domain.Phones;

namespace Don.PhonebookCore2.Domain.Phone
{
    [AutoMapFrom(typeof(Phones.Phone))]
    public class PhoneInPersonDto : CreationAuditedEntityDto<long>
    {
        public PhoneType Type { get; set; }
        public string Number { get; set; }
    }
}