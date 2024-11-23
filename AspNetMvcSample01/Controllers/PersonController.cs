using AspNetMvcSample01.ApplicationServices.Dtos.Person;
using AspNetMvcSample01.Models.Frameworks.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcSample01.Controllers
{
    public class PersonController : Controller
    {

        #region [- Ctor() -]

        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        #endregion

        #region [- Create() -]

        [HttpPost]
        public async Task<IActionResult> Insert(DtoPostPerson person)
        {
            if (ModelState.IsValid)
            {
                await _personService.Insert(person);
                return RedirectToAction("Index");
            }
            return View(person);
        }
        #endregion

        #region [- Select() -]

        public async Task<IActionResult> Index()
        {
            return View(_personService.Select());
        }
        #endregion

        #region [- Delete() -]

        [HttpPost]
        public async Task<IActionResult> Delete(long id)
        {
            if (ModelState.IsValid)
            {
                await _personService.Delete(id);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Index");
            }
        }
        #endregion

        #region [- Edit() -]

        [HttpPost]
        public async Task <IActionResult> Edit([Bind ("FName,LName")] DtoGetPerson person)
        {
            if (ModelState.IsValid)
            {
                await _personService.Update(person);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Index");
            }
        }

        #endregion
    }
}
