﻿using TempLaboClini.Domain.Entities;

namespace TempLaboClini.Domain.Interfaces
{
    public interface IPacienteRepository : IGenericRepository<BaseEntity, Paciente>
    {

        Persona GetByNroIdentificacion(string nroIdentificacion);
        IEnumerable<Persona> GetByNombreCompleto(string nombre, string apellido, string segundoApellido = null);
        IEnumerable<Persona> GetByFechaNacimientoRange(DateTime desde, DateTime hasta);
        IEnumerable<Persona> GetAllWithDireccion();
    }
}
