using Dapper;
using Mapster;
using MediatR;
using RubricaUrp.Backend.Application.Base;
using RubricaUrp.Backend.Domain.Models;
using RubricaUrp.Backend.Domain.Repositories;
using RubricaUrp.Backend.Domain.UoW;
using RubricaUrp.Backend.Infrastructure.Repositories;
using RubricaUrp.Backend.Domain.Utils;
using System.Data;

namespace RubricaUrp.Backend.Application.Commands.Curso.Insert
{
    public class InsertCursoCommandHandler : IRequestHandler<InsertCursoCommand, ResponseModel>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICursoRepository cursoRepository;
        private readonly IRubricaRepository rubricaRepository;
        public InsertCursoCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            cursoRepository = new CursoRepository(unitOfWork.Connection, unitOfWork.Transaction);
            rubricaRepository = new RubricaRepository(unitOfWork.Connection, unitOfWork.Transaction);
        }
        public async Task<ResponseModel> Handle(InsertCursoCommand request, CancellationToken cancellationToken)
        {
            var curso = request.Adapt<CursoModel>();
            var id = await cursoRepository.Insert(curso);
            await unitOfWork.Connection.ExecuteAsync("Rubrica.SaveRubricas", new { Rubricas = request.Rubricas.ToDataTable().AsTableValuedParameter("Rubrica.UDT_Rubrica"), IdCurso = id, UsuarioCreacion = 1 }, unitOfWork.Transaction, null, CommandType.StoredProcedure);
            unitOfWork.Commit();
            return new ResponseModel { Data = id, Message = "Se registró el curso con éxito" };
        }
    }
}
