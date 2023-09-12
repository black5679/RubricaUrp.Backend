using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubricaUrp.Backend.Application.Queries.Curso.GetById
{
    public class GetByIdCursoResponse
    {
        public int Id { get; set; }
        public int IdTipoCurso { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public IEnumerable<Rubrica> Rubricas { get; set; } = Enumerable.Empty<Rubrica>();
    }
    public class Rubrica
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
    }
}
