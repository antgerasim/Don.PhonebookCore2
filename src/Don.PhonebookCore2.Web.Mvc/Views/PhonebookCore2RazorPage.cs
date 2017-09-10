using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace Don.PhonebookCore2.Web.Views
{
    public abstract class PhonebookCore2RazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected PhonebookCore2RazorPage()
        {
            LocalizationSourceName = PhonebookCore2Consts.LocalizationSourceName;
        }
    }
}
