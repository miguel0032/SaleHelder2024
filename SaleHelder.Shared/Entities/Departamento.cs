using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleHelder.Shared.Entities
{
    public class Departamento
    {
        public int DepartamentoId { get; set; }
        public string Nombre { get; set; }
        public int IdCategoria { get; set; }

        public Categoria? categoria {  get; set; }
        public List<User>? Usuarios { get; set; }
        public List<FaQ>? FaQs { get; set; }
    }
}
