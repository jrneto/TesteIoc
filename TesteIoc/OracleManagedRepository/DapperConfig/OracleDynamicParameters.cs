﻿using Dapper;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace OracleManagedRepository.DapperConfig
{
    public class OracleDynamicParameters : SqlMapper.IDynamicParameters
    {
        private readonly DynamicParameters dynamicParameters = new DynamicParameters();

        private readonly List<OracleParameter> oracleParameters = new List<OracleParameter>();

        public void Add(string name, object value = null, DbType? dbType = null, ParameterDirection? direction = null, int? size = null)
        {
            dynamicParameters.Add(name, value, dbType, direction, size);
        }

        public void Add(string name, OracleDbType oracleDbType, ParameterDirection direction)
        {
            var oracleParameter = new OracleParameter(name, oracleDbType, direction);
            oracleParameters.Add(oracleParameter);
        }

        public void AddParameters(IDbCommand command, SqlMapper.Identity identity)
        {
            ((SqlMapper.IDynamicParameters)dynamicParameters).AddParameters(command, identity);

            var oracleCommand = command as OracleCommand;

            if (oracleCommand != null)
            {
                oracleCommand.Parameters.AddRange(oracleParameters.ToArray());
            }
        }

        /// <summary>
        /// recupera o valor de retorno de parametros Out
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string GetOut(int index)
        {
            return oracleParameters[index].Value.ToString();
        }


    }
}