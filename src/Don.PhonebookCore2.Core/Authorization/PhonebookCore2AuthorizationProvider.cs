using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace Don.PhonebookCore2.Authorization
{
    public class PhonebookCore2AuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);//must be logged as host, not as tenant

            /*Don added*/
            var phoneBook= context.CreatePermission(PermissionNames.Pages_Tenant_PhoneBook, L("PhoneBook"),
                multiTenancySides: MultiTenancySides.Tenant);//must be logged as tenant, not as host
            //Create Person
            phoneBook.CreateChildPermission(PermissionNames.Pages_Tenant_PhoneBook_CreatePerson,L("CreateNewPerson"),multiTenancySides:MultiTenancySides.Tenant);//must be logged as tenant, not as host
            //Delete Person
            phoneBook.CreateChildPermission(PermissionNames.Pages_Tenant_PhoneBook_DeletePerson, L("DeletePerson"),
                multiTenancySides: MultiTenancySides.Tenant);

            /*Don added end*/

            var administration = context.CreatePermission(PermissionNames.Administration, L("Administration"));
            administration.CreateChildPermission(PermissionNames.Administration_RoleManagement, L("RoleManagement"));

            var userManagement = administration.CreateChildPermission(PermissionNames.Administration_UserManagement, L("UserManagement"));
            userManagement.CreateChildPermission(PermissionNames.Administration_UserManagement_CreateUser, L("CreateUser"));
            /*Don added end*/
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PhonebookCore2Consts.LocalizationSourceName);
        }
    }
}
