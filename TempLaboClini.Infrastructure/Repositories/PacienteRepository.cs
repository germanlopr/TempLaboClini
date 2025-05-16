
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TempLaboClini.Domain.Entities;
using TempLaboClini.Domain.Interfaces;
using TempLaboClini.Infrastructure.Data;

namespace TempLaboClini.Infrastructure.Repositories
{

    public class PacienteRepository : GenericRepository<BaseEntity, Paciente>, IPacienteRepository
    {
        public PacienteRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Persona> GetAllWithDireccion()
        {
            // Retorna todas las personas que son pacientes, incluyendo su dirección
            return _context.Pacientes
                .Include(p => p.Direccion)
                .Cast<Persona>()
                .ToList();
        }

        public IEnumerable<Persona> GetByFechaNacimientoRange(DateTime desde, DateTime hasta)
        {
            return _context.Pacientes
                .Where(p => p.FechaNacimiento >= desde && p.FechaNacimiento <= hasta)
                .Cast<Persona>()
                .ToList();
        }

        public IEnumerable<Persona> GetByNombreCompleto(string nombre, string apellido, string segundoApellido = null)
        {
            var query = _dbSet.AsQueryable();

            if (!string.IsNullOrEmpty(nombre))
                query = query.Where(p => p.Nombre.Contains(nombre));

            if (!string.IsNullOrEmpty(apellido))
                query = query.Where(p => p.Apellido.Contains(apellido));

            if (!string.IsNullOrEmpty(segundoApellido))
                query = query.Where(p => p.SegundoApellido.Contains(segundoApellido));

            return query.ToList();
        }

        //public Persona GetByNroIdentificacion(string nroIdentificacion)
        //{
        //    throw new NotImplementedException();
        //}

        public Persona GetByNroIdentificacion(string id)
        => _dbSet.FirstOrDefault(p => p.NroIdentificacion == id);


    }
}
