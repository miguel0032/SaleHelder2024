
using SaleHelder.Application.Interfaces.Repositories;
using SaleHelder.Application.Interfaces.Services;
using SaleHelder.Application.ViewModels.Department;
using SaleHelder.Shared.Entities;

namespace SaleHelder.Application.Services
{
    
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _depRepository;
        public DepartmentService(IDepartmentRepository depRepository)
        {
            _depRepository= depRepository;
        }
        public async Task Add(SaveDepartmentViewModel vm)
        {
            Departamento dep = new Departamento
            {
                Nombre = vm.Name,
                IdCategoria= vm.IdCategory,
            };
            await _depRepository.Add(dep);
        }

        public async Task<List<DepartmentViewModel>> GetAll()
        {
            var departments = await _depRepository.GetAll();
            return departments.Select(data => new DepartmentViewModel
            {
                Id = data.DepartamentoId,
                Name = data.Nombre
            }).ToList();
        }

        public async Task<DepartmentViewModel> GetByIdViewModel(int id)
        {
            var department = await _depRepository.GetById(id);
            return new DepartmentViewModel
            {
                Id = department.DepartamentoId,
                Name = department.Nombre
            };
        }

        public async Task Remove(SaveDepartmentViewModel vm)
        {
            Departamento dep = await _depRepository.GetById(vm.Id);
            dep.Nombre = vm.Name;

            await _depRepository.Update(dep);
        }

        public async Task Update(SaveDepartmentViewModel vm)
        {
            Departamento dep = await _depRepository.GetById(vm.Id);
            dep.Nombre = vm.Name;

            await _depRepository.Update(dep);
        }
    }
}
