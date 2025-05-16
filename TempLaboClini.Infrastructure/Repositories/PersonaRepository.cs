using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TempLaboClini.Domain.Entities;
using TempLaboClini.Domain.Interfaces;
using TempLaboClini.Infrastructure.Data;

namespace TempLaboClini.Infrastructure.Repositories
{
    public class PersonaRepository : GenericRepository<BaseEntity, Persona>, IPersonaRepository
    {
        public PersonaRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Persona GetByNroIdentificacion(string nroIdentificacion)
        {
            return _dbSet.FirstOrDefault(p => p.NroIdentificacion == nroIdentificacion);
        }

        public IEnumerable<Persona> GetByNombreCompleto(string nombre, string apellido, string segundoApellido = null)
        {
            var query = _dbSet.Where(p =>
                p.Nombre.Contains(nombre) &&
                p.Apellido.Contains(apellido) &&
                (string.IsNullOrEmpty(segundoApellido) || p.SegundoApellido.Contains(segundoApellido)));

            return query.ToList();
        }

        public IEnumerable<Persona> GetByFechaNacimientoRange(DateTime desde, DateTime hasta)
        {
            return _dbSet.Where(p => p.FechaNacimiento >= desde && p.FechaNacimiento <= hasta).ToList();
        }

        public IEnumerable<Persona> GetAllWithDireccion()
        {
            return _dbSet.Include(p => p.Direccion).ToList();
        }
    }
}
