using Abp.Authorization;
using Don.PhonebookCore2.Authorization.Roles;
using Don.PhonebookCore2.Authorization.Users;

namespace Don.PhonebookCore2.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
