using Microsoft.AspNetCore.Mvc;
using SaleHelder.Application.Interfaces.Services;
using SaleHelder.Application.ViewModels.Department;
using SaleHelder.Application.ViewModels.Faq;

namespace Presentation.Controllers
{
    public class FaQController : Controller
    {
        private readonly IFaqService _faqService;
        private readonly IDepartmentService _depService;
        public FaQController(IFaqService faqService, IDepartmentService depService)
        {
            _faqService = faqService;
            _depService = depService;
        }
        public async Task<IActionResult> Index()
        {
            var listF = await _faqService.GetAll();
            return View(listF);
        }

        public async Task<IActionResult> Create()
        {
            var dep = await _depService.GetAll();
            return View(new SaveFaqViewModel {Departments =  dep });
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveFaqViewModel vm)
        {
         
            await _faqService.Add(vm);
            return RedirectToRoute(new { controller="FaQ",action="Index"});
        }
    }
}
