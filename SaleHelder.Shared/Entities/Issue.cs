using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleHelder.Shared.Entities
{
    public class Issue
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public bool Estado { get; set; }
        public int IdUsuario { get; set; }

        public int IdFaq { get; set; }

        public FaQ? FaQ { get; set; }
        public User? User { get; set; }
    }
}
