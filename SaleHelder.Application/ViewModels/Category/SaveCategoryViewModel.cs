

using System.ComponentModel.DataAnnotations;

namespace SaleHelder.Application.ViewModels.Category
{
    public class SaveCategoryViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Debe colocarle un nombre")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
    }
}
