using Entidades;
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

        public IList<Paciente> BuscarPulicoAlvo()
        {
            using (var command = _conn.CreateCommand())
            {

                command.Parameters.Add(DbCommandExtensions.CreateParameter(command, "PO_CURSOR",  ParameterDirection.Output)); 

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GDD.TESTE_TNH";

                return this.ToList(command).ToList();
            }
        }

 
    }
}
