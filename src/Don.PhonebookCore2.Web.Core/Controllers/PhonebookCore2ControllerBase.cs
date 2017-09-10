using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Don.PhonebookCore2.Controllers
{
    public abstract class PhonebookCore2ControllerBase: AbpController
    {
        protected PhonebookCore2ControllerBase()
        {
            LocalizationSourceName = PhonebookCore2Consts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}