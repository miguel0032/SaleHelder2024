using SaleHelder.Application.Interfaces.Repositories;
using SaleHelder.Application.Interfaces.Services;
using SaleHelder.Application.ViewModels.Faq;
using SaleHelder.Shared.Entities;

namespace SaleHelder.Application.Services
{
    public class FaqService : IFaqService
    {
        private readonly IFaqRepository _faqRepository;
        public FaqService(IFaqRepository faqRepository)
        {
            _faqRepository= faqRepository;
        }
        public async Task Add(SaveFaqViewModel vm)
        {
            FaQ faq = new FaQ
            {
                FaQId = vm.id,
                Pregunta = vm.question,
                Respuesta = vm.Answer, 
                IdDepartamento = vm.IdDep,
            };

            await _faqRepository.Add(faq);
        }

        public async Task<List<FaqViewModel>> GetAll()
        {
            var list = await _faqRepository.GetAll();
            return list.Select(data => new FaqViewModel
            {
                id = data.FaQId,
                question = data.Pregunta,
                Answer = data.Respuesta,
            }).ToList();
        }

        public async Task<FaqViewModel> GetByIdViewModel(int id)
        {
            var faq = await _faqRepository.GetById(id);
            return new FaqViewModel
            {
                id = faq.FaQId,
                question = faq.Pregunta,
                Answer =  faq.Respuesta,
            };
        }

        public async Task Remove(SaveFaqViewModel vm)
        {
            FaQ faq = await _faqRepository.GetById(vm.id);
            await _faqRepository.Delete(faq);
        }

        public async Task Update(SaveFaqViewModel vm)
        {
            FaQ faq = await _faqRepository.GetById(vm.id);
            faq.Respuesta = vm.Answer;
            faq.Pregunta = vm.question;
            faq.IdDepartamento = vm.IdDep;

           
        }
    }
}
