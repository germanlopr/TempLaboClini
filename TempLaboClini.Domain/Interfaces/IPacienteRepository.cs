using TempLaboClini.Domain.Entities;

namespace TempLaboClini.Domain.Interfaces
{
    public interface IPacienteRepository
    {
        Paciente GetByIdentificacion(string nroIdentificacion);
    }
}
