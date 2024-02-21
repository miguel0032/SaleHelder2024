using Microsoft.AspNetCore.Mvc;
using SaleHelder.Application.Interfaces.Services;
using SaleHelder.Application.ViewModels.Category;

namespace Presentation.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAll();
            return View(categories);
        }

        public IActionResult Create() 
        {
            return View(new SaveCategoryViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveCategoryViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            await _categoryService.Add(vm);
            return RedirectToRoute(new { controller = "Category", action = "Index" });
        }
    }
}
