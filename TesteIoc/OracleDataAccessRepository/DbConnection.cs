using System;
using System.Data;

namespace OracleDataAccessRepository
{
    public class DbConnection : IDisposable
    {
        private readonly IDbConnection _connection;
        private readonly IConnectionFactory _connectionFactory; 

        public DbConnection(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
            _connection = _connectionFactory.Create();
        } 

        public IDbCommand CreateCommand()
        {
            var cmd = _connection.CreateCommand();
            return cmd;
        }
 
        public void Dispose()
        {
            _connection.Dispose();
        }


    }
}
