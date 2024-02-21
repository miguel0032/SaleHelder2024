

namespace SaleHelder.Shared.Entities
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }

        public List<Departamento>? Departamentos{ get;}
    }
}
