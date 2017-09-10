using System.Collections.Generic;
using Don.PhonebookCore2.Roles.Dto;
using Don.PhonebookCore2.Users.Dto;

namespace Don.PhonebookCore2.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}