using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleDataAccessRepository
{
    public static class ConnectionHelper
    {
        public static IConnectionFactory GetConnection(string connectionName = "ISSP_DATAACCESS")
        { 
            return new DbConnectionFactory(connectionName); 
        }
    }
}
