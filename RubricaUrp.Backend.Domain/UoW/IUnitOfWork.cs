using System.Data;

namespace RubricaUrp.Backend.Domain.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IDbTransaction Transaction { get; }

        IDbConnection Connection { get; }

        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);

        bool Commit();

        void Rollback();
    }
}
