using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleHelder.Shared.Entities
{
    public class User
    {

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Apellido { get; set; }         
        public int DepartamentoId { get; set; }
        public int TipoUsuario { get; set; }
        public string Nombres { get; set; }
        public string Pass { get; set; }
        public Departamento? Departamento { get; set; }

        public List<Issue>? issues { get; set; }
    }
}
