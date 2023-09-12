using RubricaUrp.Backend.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubricaUrp.Backend.Domain.Models
{
    public class CursoModel : AuditModel
    {
        public int Id { get; set; }
        public required int IdTipoCurso { get; set; }
        public required string Codigo { get; set; }
        public required string Nombre { get; set; }
    }
}
