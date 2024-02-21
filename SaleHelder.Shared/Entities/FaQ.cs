

namespace SaleHelder.Shared.Entities
{
    public class FaQ
    {
        public int FaQId { get; set; }
        public string Pregunta { get; set; }
        public string? Respuesta { get; set; }
        public int IdDepartamento { get; set; }

        public Departamento? departamento { get; set; }
        public List<Issue>? issues { get; set; }
    }
}
