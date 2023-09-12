using RubricaUrp.Backend.Domain.UoW;
using System.Data;

namespace RubricaUrp.Backend.Infrastructure.UoW
{
    public class Db : IDb
    {
        private readonly Lazy<IDbConnection> _connection = null!;

        private readonly IDbConnection _externalConnection;

        private bool _disposed;

        public IDbConnection Connection
        {
            get
            {
                Connect();
                return _externalConnection ?? _connection.Value;
            }
        }

        public Db(IDbConnection connection)
        {
            _externalConnection = connection;
            _disposed = false;
        }

        public void Connect()
        {
            IDbConnection dbConnection = _externalConnection ?? _connection.Value;
            if (dbConnection.State != ConnectionState.Open)
            {
                dbConnection.Open();
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                if (_externalConnection != null && _externalConnection.State == ConnectionState.Open)
                {
                    _externalConnection.Close();
                }

                _connection?.Value.Close();
            }

            _disposed = true;
        }
    }
}
