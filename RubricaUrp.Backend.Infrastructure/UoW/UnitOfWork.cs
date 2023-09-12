using RubricaUrp.Backend.Domain.UoW;
using System.Data;
using System.Data.Common;

namespace RubricaUrp.Backend.Infrastructure.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDb _db;

        private bool _disposed;

        private DbTransaction _transaction = null!;
        public IDbTransaction Transaction => _transaction;

        public IDbConnection Connection => _db.Connection;

        public UnitOfWork(IDb db)
        {
            _db = db;
            _disposed = false;
            BeginTransaction();
        }
        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            if (_db.Connection.State != ConnectionState.Open)
            {
                _db.Connection.Open();
            }

            _transaction = (DbTransaction)_db.Connection.BeginTransaction(isolationLevel);
        }

        public bool Commit()
        {
            if (_transaction?.Connection == null)
            {
                return false;
            }

            _transaction.Commit();
            return true;
        }

        public void Rollback()
        {
            if (_transaction.Connection != null)
            {
                _transaction.Rollback();
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing && _db != null)
            {
                if (_db.Connection.State == ConnectionState.Open)
                {
                    _db.Connection.Close();
                }

                if (_transaction?.Connection != null)
                {
                    ((IDisposable)_transaction).Dispose();
                }
                _db?.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
