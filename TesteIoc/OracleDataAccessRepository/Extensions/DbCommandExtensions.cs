using Oracle.DataAccess.Client;
using System;
using System.Data;

namespace OracleDataAccessRepository.Extensions
{
    public static class DbCommandExtensions
    {
        
        public static IDbDataParameter CreateParameter(this IDbCommand command, string name, object value, ParameterDirection parameterDirection, OracleDbType oracleDbType)
        {
            var parameter = (command as OracleCommand).CreateParameter();
            parameter.ParameterName = name;
            if(value != null && value.GetType() == typeof(DateTime))
            {
                parameter.Value = Convert.ToDateTime(value) == DateTime.MinValue ? DBNull.Value : value;
            }
            else
            {
                parameter.Value = value ?? DBNull.Value;
            } 

            parameter.OracleDbType = oracleDbType;
            parameter.Direction = parameterDirection;
            return parameter;
        }

        

        
    }
}
