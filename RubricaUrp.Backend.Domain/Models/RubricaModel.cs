using RubricaUrp.Backend.Domain.Base;

namespace RubricaUrp.Backend.Domain.Models
{
    public class RubricaModel : AuditModel
    {
        public int Id { get; set; }
        public required int IdCurso { get; set; }
        public required string Nombre { get; set; }
    }
}
