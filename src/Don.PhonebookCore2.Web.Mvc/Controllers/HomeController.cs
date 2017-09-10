using Abp.AspNetCore.Mvc.Authorization;
using Don.PhonebookCore2.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Don.PhonebookCore2.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : PhonebookCore2ControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}