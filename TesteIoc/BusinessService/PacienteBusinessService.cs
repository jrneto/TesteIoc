using System.Collections.Generic;
using BusinessInterface;
using Entidades;
using RepositoryInterfaces;

namespace BusinessService
{
    public class PacienteBusinessService : IPacienteBusinessService
    {
        IPacienteRepository _rep;
        public PacienteBusinessService(IPacienteRepository rep)
        {
            _rep = rep;
        }

        public IList<Paciente> BuscarPublicoAlvo()
        {
            return _rep.BuscarPulicoAlvo();
        }

   
    }
}
