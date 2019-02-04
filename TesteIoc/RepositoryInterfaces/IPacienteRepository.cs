using Entidades;
using System.Collections.Generic;

namespace RepositoryInterfaces
{
    public interface IPacienteRepository
    {
        IList<Paciente> BuscarPulicoAlvo();
    }
}
