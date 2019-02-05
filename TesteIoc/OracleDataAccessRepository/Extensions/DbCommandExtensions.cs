using System;
using System.Data;

namespace OracleDataAccessRepository.Extensions
{
    public static class DbCommandExtensions
    {
        public static IDbDataParameter CreateParameter(this IDbCommand command, string name, object value)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = name;
            if(value != null && value.GetType() == typeof(DateTime))
            {
                parameter.Value = Convert.ToDateTime(value) == DateTime.MinValue ? DBNull.Value : value;
            }
            else
            {
                parameter.Value = value ?? DBNull.Value;
            }

            
            //parameter.DbType = DbType.String;
            return parameter;
        }

        public static IDbDataParameter CreateParameter(this IDbCommand command, string name,  ParameterDirection parameterDirection)
        {
            var parameter = CreateParameter(command, name, null); 
            parameter.Direction = parameterDirection;
            return parameter;
        }
    }
}
