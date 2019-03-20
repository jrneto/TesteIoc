
using BusinessInterface;
using BusinessService;
using Entidades;
using Ninject;
using NUnit.Framework;
using OracleDataAccessRepository;
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
        IPacienteBusinessService service = null;
        IKernel container = null;

        public TestPacienteBusinessService()
        {
            ConfigureContainer();
        }

        private void ConfigureContainer()
        {
            container = new StandardKernel();
            container.Bind<IPacienteRepository>().To<PacienteRepository>()                
                .InSingletonScope();
            container.Bind<IPacienteBusinessService>().To<PacienteBusinessService>()
                .InSingletonScope();
        }


        [Test]
        public void BuscaPaciente_OracleManaged()
        {
            log.Info("Inicio BuscaPaciente_OracleManaged");
            rep = container.Get<PacienteRepository>();
            //service = new PacienteBusinessService(rep);
            var param = new Ninject.Parameters.ConstructorArgument("PacienteRepository", rep);
            service = container.Get<PacienteBusinessService>(param);
            IList<Paciente> pacientes = service.BuscarPublicoAlvo();
            log.Info("Fim BuscaPaciente_OracleManaged");
            Assert.IsNotNull(pacientes);
            Assert.IsTrue(pacientes.Count > 0);
        }

        

        [Test]
        public void BuscaPaciente_OracleDataAccess()
        {
            log.Info("Inicio BuscaPaciente_OracleDataAccess");
            rep = new PacienteRepositoryDataAccess();
            service = new PacienteBusinessService(rep);
            IList<Paciente> pacientes = service.BuscarPublicoAlvo();
            log.Info("Fim BuscaPaciente_OracleDataAccess");
            Assert.IsNotNull(pacientes);
            Assert.IsTrue(pacientes.Count > 0);
        }
    }
}
