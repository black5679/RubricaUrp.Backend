using Mapster;
using MediatR;
using RubricaUrp.Backend.Domain.Repositories;
using RubricaUrp.Backend.Domain.UoW;
using RubricaUrp.Backend.Infrastructure.Repositories;

namespace RubricaUrp.Backend.Application.Queries.Curso.GetById
{
    public class GetByIdCursoQueryHandler : IRequestHandler<GetByIdCursoQuery, GetByIdCursoResponse>
    {
        private readonly ICursoRepository cursoRepository;
        private readonly IRubricaRepository rubricaRepository;
        public GetByIdCursoQueryHandler(IDb db)
        {
            cursoRepository = new CursoRepository(db.Connection, null);
            rubricaRepository = new RubricaRepository(db.Connection, null);
        }
        public async Task<GetByIdCursoResponse> Handle(GetByIdCursoQuery request, CancellationToken cancellationToken)
        {
            var curso = await cursoRepository.GetById(request.Id);
            var response = curso.Adapt<GetByIdCursoResponse>();
            var rubricas = await rubricaRepository.GetByIdCurso(request.Id);
            response.Rubricas = rubricas.Adapt<IEnumerable<Rubrica>>();
            return response;
        }
    }
}
