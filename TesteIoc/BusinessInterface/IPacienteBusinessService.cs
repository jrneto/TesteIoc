using Entidades;
using System.Collections.Generic;

namespace BusinessInterface
{
    public interface IPacienteBusinessService
    {
        IList<Paciente> BuscarPublicoAlvo();
    }
}
