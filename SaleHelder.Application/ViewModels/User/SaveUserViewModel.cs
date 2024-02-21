

using SaleHelder.Application.ViewModels.Department;
using System.ComponentModel.DataAnnotations;

namespace SaleHelder.Application.ViewModels.User
{
    public class SaveUserViewModel
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Lastname { get; set; }
        [Required]
        [Range(0,int.MaxValue)]
        public int IdDepartment { get; set; }
        [Required]
        [Range(0,int.MaxValue)]
        public int UserType { get; set; }

        public List<DepartmentViewModel> departments { get; set; } 
    }
}
