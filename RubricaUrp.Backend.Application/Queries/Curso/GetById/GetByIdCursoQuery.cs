using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubricaUrp.Backend.Application.Queries.Curso.GetById
{
    public class GetByIdCursoQuery : IRequest<GetByIdCursoResponse>
    {
        public required int Id { get; set; }
    }
}
