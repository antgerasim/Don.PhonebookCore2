namespace Don.PhonebookCore2.Authorization
{
    public static class PermissionNames
    {
        public const string Pages_Tenants = "Pages.Tenants";

        public const string Pages_Users = "Pages.Users";

        public const string Pages_Roles = "Pages.Roles";

        public const string Pages_Tenant_PhoneBook = "Pages.Tenants.PhoneBook";
        public const string Pages_Tenant_PhoneBook_CreatePerson = "Pages.Tenants.PhoneBook.CreatePerson";
        public const string Pages_Tenant_PhoneBook_DeletePerson = "Pages.Tenants.PhoneBook.DeletePerson";

        /*Don added*/
        public const string Administration = "Administration";
        public const string Administration_RoleManagement = "Administration.RoleManagement";
        public const string Administration_UserManagement = "Administration.UserManagement";
        public const string Administration_UserManagement_CreateUser = "Administration.UserManagement.CreateUser";
    }
}