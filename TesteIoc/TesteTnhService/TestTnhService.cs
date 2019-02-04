using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Timers;

namespace TesteTnhService
{
    public partial class TestTnhService : ServiceBase
    {
        static System.Timers.Timer iTimer;
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public TestTnhService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //Descomente para debugar o serviço
            //System.Diagnostics.Debugger.Launch();


            string versao = Assembly.GetExecutingAssembly().FullName;
            log.Info(string.Format("Servico Iniciado. - {0}", versao));

            iTimer = new System.Timers.Timer();
            iTimer.AutoReset = true;
            iTimer.Elapsed += new ElapsedEventHandler(onTimerTick);
            iTimer.Interval = CalculaProximoIntervaloExecucao();
            iTimer.Interval = 1; //start imediato

            iTimer.Start();
        }

        protected override void OnStop()
        {
        }

        /// <summary>
        /// metodo para iniciar os eventos no intervalo determinado 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        static void onTimerTick(object source, ElapsedEventArgs e)
        {
            iTimer.Stop();
            IniciaEventosIntegracaoTNH();
            iTimer.Start();
        }

        /// <summary>
        /// Metodo responsavel por invokar os eventos 
        /// </summary>
        static void IniciaEventosIntegracaoTNH()
        {
            log.Info("Inicio execucao eventos");
            //List<EventoBase> listaEventos = new List<EventoBase>();

            //foreach (var evento in PAPIntegracao.Core.Negocio.DicionarioDados.DDHistoricoEvento.ClasseEvento)
            //{
            //    listaEventos.Add((EventoBase)Activator.CreateInstance(PAPIntegracao.Core.Negocio.DicionarioDados.DDHistoricoEvento.ClasseEvento[evento.Key]));
            //}

            //listaEventos.ForEach(a => a.Iniciar());

            ////Setando o tempo da próxima execução 
            //iTimer.Interval = CalculaProximoIntervaloExecucao();

            log.Info("Fim execucao eventos");
        }

        /// <summary>
        /// Metodo responsavel por calcular o tempo de espera da proxima execução dos eventos 
        /// </summary>
        /// <returns></returns>
        private static double CalculaProximoIntervaloExecucao()
        {
            TimeSpan tempoEspera = Convert.ToDateTime(DateTime.Now.AddDays(1).ToString(ConfigurationManager.AppSettings["StartEventos"].ToString())) - DateTime.Now;

            return tempoEspera.TotalMilliseconds;
        }
    }
}
