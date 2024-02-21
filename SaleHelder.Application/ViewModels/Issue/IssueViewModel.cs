

namespace SaleHelder.Application.ViewModels.Issue
{
    public class IssueViewModel
    {
        public int Id { get; set; }

        public int IdUser { get; set; }
        public string NameUser { get; set; }
        public int IdFaq { get; set; }
        
        public string Problem { get; set; }
        public DateTime Date { get; set; }
        public string ImgUrl { get; set; }
        public bool Status { get; set; }
    }
}
