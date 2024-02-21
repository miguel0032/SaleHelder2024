
using SaleHelder.Application.ViewModels.Department;
using System.ComponentModel.DataAnnotations;

namespace SaleHelder.Application.ViewModels.Faq
{
    public class SaveFaqViewModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Debe colocarle la pregunta")]
        [DataType(DataType.Text)]
        public string question { get; set; }
        [Required(ErrorMessage = "Debe colocarle un codigo valido")]
        [Range(0,int.MaxValue)]
        public int IdDep { get; set; }

        public string? Answer { get; set; }

        public List<DepartmentViewModel> Departments { get; set; }
    }
}
