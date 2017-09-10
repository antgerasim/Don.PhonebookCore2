using System.Threading.Tasks;
using Abp.AutoMapper;
using Don.PhonebookCore2.Sessions;
using Microsoft.AspNetCore.Mvc;

namespace Don.PhonebookCore2.Web.Views.Shared.Components.TenantChange
{
    public class TenantChangeViewComponent : PhonebookCore2ViewComponent
    {
        private readonly ISessionAppService _sessionAppService;

        public TenantChangeViewComponent(ISessionAppService sessionAppService)
        {
            _sessionAppService = sessionAppService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loginInfo = await _sessionAppService.GetCurrentLoginInformations();
            var model = loginInfo.MapTo<TenantChangeViewModel>();
            return View(model);
        }
    }
}
