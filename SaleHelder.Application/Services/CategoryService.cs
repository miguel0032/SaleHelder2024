

using SaleHelder.Application.Interfaces.Repositories;
using SaleHelder.Application.Interfaces.Services;
using SaleHelder.Application.ViewModels.Category;
using SaleHelder.Shared.Entities;

namespace SaleHelder.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task Add(SaveCategoryViewModel vm)
        {
           Categoria category = new Categoria
           {
               CategoriaId = vm.Id,
               Nombre = vm.Name
           };
            await _categoryRepository.Add(category);
        }

        public async Task<List<CategoryViewModel>> GetAll()
        {
            var list = await _categoryRepository.GetAll();
            return list.Select(data => new CategoryViewModel
            {
                Id = data.CategoriaId,
                Name = data.Nombre
            }).ToList(); 
        }

        public async Task<CategoryViewModel> GetByIdViewModel(int id)
        {
            var category = await _categoryRepository.GetById(id);
            return new CategoryViewModel
            {
                Id = category.CategoriaId,
                Name = category.Nombre
            };
        }

        public async Task Remove(SaveCategoryViewModel vm)
        {
            Categoria category = await _categoryRepository.GetById(vm.Id);
            await _categoryRepository.Delete(category);
        }

        public async Task Update(SaveCategoryViewModel vm)
        {
            Categoria category = await _categoryRepository.GetById(vm.Id);
            category.Nombre = vm.Name;
            await _categoryRepository.Update(category);
        }
    }
}
