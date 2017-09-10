using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Don.PhonebookCore2.Authorization.Users;
using Don.PhonebookCore2.Users;

namespace Don.PhonebookCore2.Sessions.Dto
{
    [AutoMapFrom(typeof(User))]
    public class UserLoginInfoDto : EntityDto<long>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string EmailAddress { get; set; }
    }
}
