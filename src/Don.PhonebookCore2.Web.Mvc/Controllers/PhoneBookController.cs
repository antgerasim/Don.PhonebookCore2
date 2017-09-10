using Don.PhonebookCore2.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Don.PhonebookCore2.Web.Controllers
{
    public class PhoneBookController : PhonebookCore2ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}