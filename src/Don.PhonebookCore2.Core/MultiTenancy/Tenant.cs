using Abp.MultiTenancy;
using Don.PhonebookCore2.Authorization.Users;

namespace Don.PhonebookCore2.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {
            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}