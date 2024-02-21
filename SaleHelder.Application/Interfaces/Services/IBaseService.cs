

using System.ComponentModel;

namespace SaleHelder.Application.Interfaces.Services
{
    public interface IBaseService<SaveViewModel,ViewModel>
    {
        Task Add(SaveViewModel vm);
        Task Remove(SaveViewModel vm);
        Task Update(SaveViewModel vm);
        Task<List<ViewModel>> GetAll();
        Task<ViewModel> GetByIdViewModel(int id);
    }
}
