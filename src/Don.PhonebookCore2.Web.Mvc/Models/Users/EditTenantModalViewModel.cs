using System.Collections.Generic;
using System.Linq;
using Don.PhonebookCore2.Roles.Dto;
using Don.PhonebookCore2.Users.Dto;

namespace Don.PhonebookCore2.Web.Models.Users
{
    public class EditUserModalViewModel
    {
        public UserDto User { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }

        public bool UserIsInRole(RoleDto role)
        {
            return User.RoleNames != null && User.RoleNames.Any(r => r == role.NormalizedName);
        }
    }
}