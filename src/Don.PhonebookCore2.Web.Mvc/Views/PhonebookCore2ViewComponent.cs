using Abp.AspNetCore.Mvc.ViewComponents;

namespace Don.PhonebookCore2.Web.Views
{
    public abstract class PhonebookCore2ViewComponent : AbpViewComponent
    {
        protected PhonebookCore2ViewComponent()
        {
            LocalizationSourceName = PhonebookCore2Consts.LocalizationSourceName;
        }
    }
}