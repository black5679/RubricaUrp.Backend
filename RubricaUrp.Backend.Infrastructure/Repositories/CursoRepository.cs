using Dapper;
using RubricaUrp.Backend.Domain.Models;
using RubricaUrp.Backend.Domain.Repositories;
using System.Data;

namespace RubricaUrp.Backend.Infrastructure.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly IDbConnection connection;
        private readonly IDbTransaction? transaction;
        public CursoRepository(IDbConnection connection, IDbTransaction? transaction)
        {
            this.connection = connection;
            this.transaction = transaction;
        }
        public async Task<CursoModel> GetById(int id)
        {
            var curso = await connection.QueryFirstOrDefaultAsync<CursoModel>("Malla.GetCursoById", new { Id = id }, transaction, null, CommandType.StoredProcedure);
            return curso;
        }
        public async Task<int> Insert(CursoModel curso)
        {
            var id = await connection.ExecuteScalarAsync<int>("Malla.InsertCurso", new { curso.IdTipoCurso, curso.Nombre, curso.Codigo, UsuarioCreacion = 1 }, transaction, null, CommandType.StoredProcedure);
            return id;
        }
    }
}
