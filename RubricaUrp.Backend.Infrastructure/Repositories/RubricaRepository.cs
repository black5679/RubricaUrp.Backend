using Dapper;
using RubricaUrp.Backend.Domain.Models;
using RubricaUrp.Backend.Domain.Utils;
using RubricaUrp.Backend.Domain.Repositories;
using System.Data;

namespace RubricaUrp.Backend.Infrastructure.Repositories
{
    public class RubricaRepository : IRubricaRepository
    {
        private readonly IDbConnection connection;
        private readonly IDbTransaction? transaction;
        public RubricaRepository(IDbConnection connection, IDbTransaction? transaction)
        {
            this.connection = connection;
            this.transaction = transaction;
        }
        public async Task<IEnumerable<RubricaModel>> GetByIdCurso(int idCurso)
        {
            var rubricas = await connection.QueryAsync<RubricaModel>("Rubrica.GetRubricasByIdCurso", new { IdCurso = idCurso }, transaction, null, CommandType.StoredProcedure);
            return rubricas;
        }
        public async Task Save(List<RubricaModel> rubricas, int idCurso)
        {
            await connection.ExecuteAsync("Rubrica.SaveRubricas", new { Rubricas = rubricas.ToDataTable().AsTableValuedParameter("Rubrica.UDT_Rubrica"), IdCurso = idCurso, UsuarioCreacion = 1 }, transaction, null, CommandType.StoredProcedure);
        }
    }
}
