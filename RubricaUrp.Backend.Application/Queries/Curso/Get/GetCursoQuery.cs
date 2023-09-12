using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubricaUrp.Backend.Application.Queries.Curso.Get
{
    public class GetCursoQuery : IRequest<IEnumerable<GetCursoResponse>>
    {
    }
}
