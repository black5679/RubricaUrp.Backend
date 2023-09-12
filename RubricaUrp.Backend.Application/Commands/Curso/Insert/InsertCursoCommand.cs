using MediatR;
using RubricaUrp.Backend.Application.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubricaUrp.Backend.Application.Commands.Curso.Insert
{
    public class InsertCursoCommand : IRequest<ResponseModel>
    {
        public required int IdTipoCurso { get; set; }
        public required string Codigo { get; set; }
        public required string Nombre { get; set; }
        public required List<Rubrica> Rubricas { get; set; }
    }

    public class Rubrica
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
    }
}
