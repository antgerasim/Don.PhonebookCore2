using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Don.PhonebookCore2.MultiTenancy;
using Abp.Runtime.Session;
using Abp.IdentityFramework;
using Don.PhonebookCore2.Authorization.Users;
using Microsoft.AspNetCore.Identity;

namespace Don.PhonebookCore2
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class PhonebookCore2AppServiceBase : ApplicationService
    {
        public TenantManager TenantManager { get; set; }

        public UserManager UserManager { get; set; }

        protected PhonebookCore2AppServiceBase()
        {
            LocalizationSourceName = PhonebookCore2Consts.LocalizationSourceName;
        }

        protected virtual Task<User> GetCurrentUserAsync()
        {
            var user = UserManager.FindByIdAsync(AbpSession.GetUserId().ToString());
            if (user == null)
            {
                throw new Exception("There is no current user!");
            }

            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}