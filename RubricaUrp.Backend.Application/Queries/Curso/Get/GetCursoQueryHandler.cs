using Dapper;
using MediatR;
using RubricaUrp.Backend.Domain.Repositories;
using RubricaUrp.Backend.Domain.UoW;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubricaUrp.Backend.Application.Queries.Curso.Get
{
    public class GetCursoQueryHandler : IRequestHandler<GetCursoQuery, IEnumerable<GetCursoResponse>>
    {
        private readonly IDb db;
        public GetCursoQueryHandler(IDb db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<GetCursoResponse>> Handle(GetCursoQuery request, CancellationToken cancellationToken)
        {
            var cursos = await db.Connection.QueryAsync<GetCursoResponse>("Malla.GetCursos", null, null, null, CommandType.StoredProcedure);
            return cursos;
        }
    }
}
