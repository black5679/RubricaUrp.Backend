using System.Data;

namespace RubricaUrp.Backend.Domain.UoW
{
    public interface IDb : IDisposable
    {
        IDbConnection Connection { get; }
        void Connect();
    }
}
