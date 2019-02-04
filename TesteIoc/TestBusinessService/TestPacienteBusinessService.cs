
using BusinessInterface;
using BusinessService;
using Entidades;
using NUnit.Framework;
using OracleManagedRepository;
using RepositoryInterfaces;
using System.Collections.Generic;

namespace TestBusinessService
{
    [TestFixture]
    public class TestPacienteBusinessService
    {
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        IPacienteRepository rep = null;
        [Test]
        public void BuscaPaciente_OracleManaged()
        {
            log.Info("Inicio BuscaPaciente_OracleManaged");
            rep = new PacienteRepository();
            IPacienteBusinessService service = new PacienteBusinessService(rep);
            IList<Paciente> pacientes = service.BuscarPublicoAlvo();
            log.Info("Inicio BuscaPaciente_OracleManaged");
            Assert.IsNotNull(pacientes);
            Assert.IsTrue(pacientes.Count > 0);
        }
    }
}
