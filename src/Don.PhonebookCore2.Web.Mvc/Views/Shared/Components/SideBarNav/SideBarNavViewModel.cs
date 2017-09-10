using Abp.Application.Navigation;

namespace Don.PhonebookCore2.Web.Views.Shared.Components.SideBarNav
{
    public class SideBarNavViewModel
    {
        public UserMenu MainMenu { get; set; }

        public string ActiveMenuItemNameFirst { get; set; }
        public string ActiveMenuItemNameSecond { get; set; }
    }
}
