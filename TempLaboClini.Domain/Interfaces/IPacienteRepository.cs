using TempLaboClini.Domain.Entities;

namespace TempLaboClini.Domain.Interfaces
{
    public interface IPacienteRepository : IRepository<Paciente>
    {
        Paciente GetByIdentificacion(string nroIdentificacion);
    }
}
