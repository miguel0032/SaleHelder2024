

using SaleHelder.Application.Interfaces.Repositories;
using SaleHelder.Application.Interfaces.Services;
using SaleHelder.Application.ViewModels.User;
using SaleHelder.Shared.Entities;
using System.Collections.Generic;

namespace SaleHelder.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task Add(SaveUserViewModel vm)
        {
            User user = new User
            {
                UserId = vm.Id,
                UserName= vm.UserName, 
                Apellido = vm.Lastname,
                DepartamentoId = vm.IdDepartment, 
                Nombres = vm.Name,
                TipoUsuario = vm.UserType,
                Pass = vm.Password
                
            };

            await _userRepository.Add(user);
        }

        public async Task<List<UserViewModel>> GetAll()
        {
            var list = await _userRepository.GetAll();
            return list.Select(data => new UserViewModel{
                Id= data.UserId,
                DepName= data.Departamento.Nombre,
                IdDepartment = data.Departamento.DepartamentoId,
                Lastname = data.Apellido,
                UserName  = data.UserName,
                UserType = data.TipoUsuario,
                Name = data.Nombres,
                Password = data.Pass

            }).ToList();
        }

        public async Task<UserViewModel> GetByIdViewModel(int id)
        {
            var user =  await _userRepository.GetById(id);
            return new UserViewModel
            {
                Id = user.UserId,
                DepName = user.Departamento.Nombre,
                IdDepartment = user.Departamento.DepartamentoId,
                Lastname = user.Apellido,
                UserName = user.UserName,
                UserType = user.TipoUsuario,
                Name = user.Nombres,
                Password = user.Pass

            };
        }

        public async Task Remove(SaveUserViewModel vm)
        {
            User user = await _userRepository.GetById(vm.Id);
            await _userRepository.Delete(user);   
        }

        public async Task Update(SaveUserViewModel vm)
        {
            User user = await _userRepository.GetById(vm.Id);
            user.UserId = vm.Id;
            user.UserName = vm.UserName;
            user.Apellido = vm.Lastname;
            user.DepartamentoId = vm.IdDepartment;
            user.Nombres = vm.Name;
            user.Pass = vm.Password;

            await _userRepository.Update(user);
        }
    }
}
