

using SaleHelder.Application.Interfaces.Repositories;
using SaleHelder.Application.Interfaces.Services;
using SaleHelder.Application.ViewModels.Issue;
using SaleHelder.Shared.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SaleHelder.Application.Services
{
    public class IssueService : IIssueService
    {
        private readonly IIssueRepository _issueRepository;
        public IssueService(IIssueRepository issueRepository)
        {
            _issueRepository = issueRepository;
        }
        public async Task Add(SaveIssueViewModel vm)
        {
            Issue issue = new Issue
            {
                Id = vm.Id,
                Descripcion = vm.Problem,
                IdUsuario = vm.IdUser,
                IdFaq= vm.IdFaq, 
                Fecha = vm.Date
            };
            await _issueRepository.Add(issue);
        }

        public async Task<List<IssueViewModel>> GetAll()
        {
            var issues = await _issueRepository.GetAll();
            return issues.Select(data => new IssueViewModel
            {
                Id = data.Id,
                IdFaq = data.IdFaq,
                IdUser = data.IdUsuario,
                NameUser = data.User.UserName,
                ImgUrl = "",
                Problem = data.Descripcion,
                Status = data.Estado,
                Date = data.Fecha
            }).ToList();
        }

        public async Task<IssueViewModel> GetByIdViewModel(int id)
        {
            var issue = await _issueRepository.GetById(id);
            return new IssueViewModel
            {
                Id = issue.Id,
                IdUser = issue.IdUsuario,
                Date = issue.Fecha,
                Problem = issue.Descripcion,
                IdFaq= issue.IdFaq,
                Status = issue.Estado,
                NameUser = issue.User.UserName,

            };
        }

        public async Task Remove(SaveIssueViewModel vm)
        {
            Issue issue = await _issueRepository.GetById(vm.Id);
            await _issueRepository.Delete(issue);
        }

        public async Task Update(SaveIssueViewModel vm)
        {
            Issue issue = await _issueRepository.GetById(vm.Id);
            issue.Id = vm.Id;
            issue.Descripcion = vm.Problem;
            issue.IdUsuario = vm.IdUser;
            issue.IdFaq = vm.IdFaq;
        }
    }
}
