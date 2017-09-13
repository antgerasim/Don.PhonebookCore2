using Don.PhonebookCore2.Controllers;
using Don.PhonebookCore2.Domain.Person;
using Don.PhonebookCore2.Domain.Person.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Don.PhonebookCore2.Web.Controllers
{
    public class PhoneBookController : PhonebookCore2ControllerBase
    {
        private readonly IPersonAppService _personAppService;

        public PhoneBookController(IPersonAppService personAppService)
        {
            _personAppService = personAppService;
        }

/*        public IActionResult Index()
        {
            return View();
        }*/
        public IActionResult Index(GetPeopleInput input)
        {
            var output = _personAppService.GetPeople(input);
            var model = new IndexViewModel(output);

            return View(model);
        }
    }
}