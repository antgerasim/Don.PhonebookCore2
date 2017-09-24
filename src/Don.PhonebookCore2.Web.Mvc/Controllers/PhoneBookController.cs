using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Runtime.Validation;
using Abp.Threading;
using Don.PhonebookCore2.Authorization;
using Don.PhonebookCore2.Controllers;
using Don.PhonebookCore2.Domain.Person;
using Don.PhonebookCore2.Domain.Person.Dto;
using Don.PhonebookCore2.Domain.Phone;
using Don.PhonebookCore2.Web.Models.PhoneBook;
using Don.PhonebookCore2.Web.Models.Roles;
using Microsoft.AspNetCore.Mvc;

namespace Don.PhonebookCore2.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Tenant_PhoneBook)]
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
            var model = new IndexViewModel(output, input.Filter);

            return View(model);
        }

        [AbpMvcAuthorize(PermissionNames.Pages_Tenant_PhoneBook_CreatePerson)]
        public ActionResult CreatePersonModal()
        {
            //return await Task.Run(() => View("_CreatePersonModal"));
            return View("_CreatePersonModal");
        }

        //[DisableValidation]
        [HttpPost]
        public async Task<PartialViewResult>
            AddPhone(
                [FromForm]
                AddPhoneInput input) //[FromBody] == contentType: 'application/json', [FromForm] ==contentType: 'application/x-www-form-urlencoded'
        {
            PhoneInPersonDto phoneInPersonList = await _personAppService.AddPhone(input);
            var model = new PhoneRowInPersonListViewModel(phoneInPersonList);

            return PartialView("_PhoneRowInPersonList", model);
        }

        public async Task<PartialViewResult> EditPersonModal(int id)
        {
            var output = await _personAppService.GetPersonForEdit(new EntityDto {Id = id});
            var viewModel = new EditPersonViewModel(output);

            return PartialView("_EditPersonModal", viewModel);
        }
    }
}