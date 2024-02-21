using Microsoft.AspNetCore.Mvc;
using SaleHelder.Application.Interfaces.Services;
using SaleHelder.Application.ViewModels.Issue;

namespace Presentation.Controllers
{
    public class IssueController : Controller
    {
        private readonly IIssueService _issueService;
        private readonly IUserService _userService;
        private readonly IFaqService _faqService;
        public IssueController(IIssueService issueService, IUserService userService, IFaqService faqService)
        {
            _issueService = issueService;
            _userService = userService;
            _faqService = faqService;
        }
        public async Task<IActionResult> Index()
        {
            var issues = await _issueService.GetAll();
            return View(issues);
        }
        public async Task<IActionResult> Get(int id)
        {
            var issue = await _issueService.GetByIdViewModel(id);
            return View(issue); 
        }

        public async Task<IActionResult> Create()
        {
            var users = await _userService.GetAll();
            var faq = await _faqService.GetAll();
            return View(new SaveIssueViewModel{ Users = users, FaQ = faq});
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveIssueViewModel vm)
        {
            await _issueService.Add(vm);
            return RedirectToRoute(new { controller = "Issue", action = "Index" });
        }
    }
}
