using Microsoft.AspNetCore.Mvc;
using SaleHelder.Application.Interfaces.Services;
using SaleHelder.Application.ViewModels.Department;

namespace Presentation.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly IDepartmentService _departmentService;
        private readonly ICategoryService _categoryService;
        public DepartmentController(IDepartmentService departmentService, ICategoryService categoryService)
        {
            _departmentService = departmentService;
            _categoryService = categoryService;
        }


        public async Task<IActionResult> Index()
        {
            var list = await _departmentService.GetAll();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var listC = await _categoryService.GetAll();
            return View(new SaveDepartmentViewModel { categories = listC });
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveDepartmentViewModel vm)
        {
           
            await _departmentService.Add(vm);
            return RedirectToRoute(new { controller = "Department", action = "Index" });
        }
    }
}
