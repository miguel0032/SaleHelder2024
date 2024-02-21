
using SaleHelder.Application.ViewModels.Category;
using SaleHelder.Shared.Entities;
using System.ComponentModel.DataAnnotations;

namespace SaleHelder.Application.ViewModels.Department
{
    public class SaveDepartmentViewModel
    {
        public int Id { get; set; }



        [Required(ErrorMessage = "Debe colocarle un nombre")]
        [DataType(DataType.Text)]
        public string Name { get; set; }


        public int IdCategory { get; set; }

        public List<CategoryViewModel> categories { get; set; }

    }
}
