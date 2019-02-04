using System.Collections.Generic;
using Entidades;
using RepositoryInterfaces;
using Oracle.ManagedDataAccess.Client;
using OracleManagedRepository.Enum;
using System;
using System.Configuration;
using System.Data;
using OracleManagedRepository.DapperConfig;
using Dapper;
using System.Linq;

namespace OracleManagedRepository
{
    public class PacienteRepository : IPacienteRepository
    {
        //protected static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public IDbConnection ObterConexao(ConexaoBD eConexao)
        {
            IDbConnection conn;
            switch (eConexao)
            {
                case ConexaoBD.ISSP:
                    string conf = ConfigurationManager.ConnectionStrings[ConexaoBD.ISSP.ToString()].ConnectionString;
                    conn = new OracleConnection(ConfigurationManager.ConnectionStrings[ConexaoBD.ISSP.ToString()].ConnectionString);
                    break;
                case ConexaoBD.ISSDES:
                    conn = new OracleConnection(ConfigurationManager.ConnectionStrings[ConexaoBD.ISSDES.ToString()].ConnectionString);
                    break;
                default:
                    throw new Exception("Conexao Invalida!");
            }

            return conn;
        }

        public IList<Paciente> BuscarPulicoAlvo()
        {
            try
            {
                using (var conn = ObterConexao(Enum.ConexaoBD.ISSP))
                {
                    string query = "GDD.TESTE_TNH";
                    var param = new OracleDynamicParameters();
                    param.Add("PO_CURSOR", OracleDbType.RefCursor, direction: ParameterDirection.Output);
                    return conn.Query<Paciente>(query, param, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                //log.Error("Erro ao buscar pacientes TNH.", ex);
                throw;
            }
        }
    }
}
