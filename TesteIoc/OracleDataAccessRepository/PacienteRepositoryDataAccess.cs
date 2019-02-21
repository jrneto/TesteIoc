using Entidades;
using Oracle.DataAccess.Client;
using OracleDataAccessRepository.Extensions;
using RepositoryInterfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace OracleDataAccessRepository
{
    public class PacienteRepositoryDataAccess : RepositoryBase<Paciente>, IPacienteRepository
    {
        private DbConnection _conn;

        public PacienteRepositoryDataAccess(DbConnection conn) 
        {
            _conn = conn;
        }

        public PacienteRepositoryDataAccess()
        {
            _conn = new DbConnection(new DbConnectionFactory("ISSP_DATAACCESS"));
        }

        public IList<Paciente> BuscarPulicoAlvo()
        {
            using (var command = _conn.CreateCommand())
            {

                command.Parameters.Add(DbCommandExtensions.CreateParameter(command, "PO_CURSOR", null, ParameterDirection.Output, OracleDbType.RefCursor)); 
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GDD.TESTE_TNH2";

                return this.ToList(command).ToList();
            }
        }

 
    }
}
