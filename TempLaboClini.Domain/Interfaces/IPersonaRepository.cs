using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempLaboClini.Domain.Entities;

namespace TempLaboClini.Domain.Interfaces
{
    // File: Repositories/Interfaces/IPersonaRepository.cs
    public interface IPersonaRepository : IGenericRepository<BaseEntity, Persona>
    {
        Persona GetByNroIdentificacion(string nroIdentificacion);
        IEnumerable<Persona> GetByNombreCompleto(string nombre, string apellido, string segundoApellido = null);
        IEnumerable<Persona> GetByFechaNacimientoRange(DateTime desde, DateTime hasta);
        IEnumerable<Persona> GetAllWithDireccion();
    }

}
