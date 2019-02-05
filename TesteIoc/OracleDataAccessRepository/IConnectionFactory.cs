using System.Data;

namespace OracleDataAccessRepository
{
    public interface IConnectionFactory
    {
        IDbConnection Create();
    }
}
