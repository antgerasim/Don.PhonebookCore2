using Don.PhonebookCore2.Controllers;
using Microsoft.AspNetCore.Antiforgery;

namespace Don.PhonebookCore2.Web.Host.Controllers
{
    public class AntiForgeryController : PhonebookCore2ControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}