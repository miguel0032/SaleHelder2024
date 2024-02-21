

using SaleHelder.Application.ViewModels.Faq;
using SaleHelder.Application.ViewModels.User;
using System.ComponentModel.DataAnnotations;

namespace SaleHelder.Application.ViewModels.Issue
{
    public class SaveIssueViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe colocarle un codigo valido")]
        [Range(0,int.MaxValue)] 
        public int IdUser { get; set; }
        [Required(ErrorMessage = "Debe colocarle un codigo valido")]
        [Range(0, int.MaxValue)]
        public int IdFaq { get; set; }
        [Required(ErrorMessage ="Debe colocar la descripcion del problema")]
        [DataType(DataType.Text)]
        public string Problem { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
        public string? ImgUrl { get; set; }

        public List<UserViewModel> Users { get; set; }
        public List<FaqViewModel> FaQ { get; set; }
    }
}
