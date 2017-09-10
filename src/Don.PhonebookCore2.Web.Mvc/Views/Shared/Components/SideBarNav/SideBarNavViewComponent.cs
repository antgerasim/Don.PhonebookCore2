using System.Threading.Tasks;
using Abp.Application.Navigation;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc;

namespace Don.PhonebookCore2.Web.Views.Shared.Components.SideBarNav
{
    public class SideBarNavViewComponent : PhonebookCore2ViewComponent
    {
        private readonly IAbpSession _abpSession;
        private readonly IUserNavigationManager _userNavigationManager;

        public SideBarNavViewComponent(
            IUserNavigationManager userNavigationManager,
            IAbpSession abpSession)
        {
            _userNavigationManager = userNavigationManager;
            _abpSession = abpSession;
        }

        public async Task<IViewComponentResult> InvokeAsync(string activeMenu = "") //convert activemenue strng to array
        {
            var result = activeMenu.Split('.');

            var first = result[0];
            var second = "";

            if (result.Length > 1)
                second = result[1];

            var model = new SideBarNavViewModel
            {
                MainMenu = await _userNavigationManager.GetMenuAsync("MainMenu", _abpSession.ToUserIdentifier()),
                ActiveMenuItemNameFirst = result[0],
                ActiveMenuItemNameSecond = second
            };
            return View(model);
        }

        //private 
    }
}