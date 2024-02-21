using Microsoft.AspNetCore.Mvc;
using SaleHelder.Application.Interfaces.Services;
using SaleHelder.Application.ViewModels.User;

namespace Presentation.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IDepartmentService _departmentService;
        public UserController(IUserService userService, IDepartmentService depService)
        {
            _userService = userService;
            _departmentService = depService;
        }
        public async Task<IActionResult> Index()
        {
            var listU = await _userService.GetAll();
            return View(listU);
        }

        public async Task<IActionResult> Create()
        {
            var deps = await _departmentService.GetAll();
            return View(new SaveUserViewModel { departments = deps});
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveUserViewModel vm)
        {
            //if (!ModelState.IsValid)
            //{
            //    var deps = await _departmentService.GetAll();
            //    vm.departments = deps;
            //    return View(vm);
            //}
            await _userService.Add(vm);
            return RedirectToRoute(new { controller = "User", action = "Index" });
        }
    }
}
