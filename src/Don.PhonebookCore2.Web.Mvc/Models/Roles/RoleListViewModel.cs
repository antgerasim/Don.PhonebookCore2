using System.Collections.Generic;
using Don.PhonebookCore2.Roles.Dto;

namespace Don.PhonebookCore2.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }

        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
