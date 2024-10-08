
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TempLaboClini.Domain.Entities;
using TempLaboClini.Domain.Interfaces;
using TempLaboClini.Infrastructure.Data;

namespace TempLaboClini.Infrastructure.Repositories
{
    public class PacienteRepository : BaseRepository<Paciente>, IPacienteRepository
    {
        public PacienteRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Paciente GetByIdentificacion(string nroIdentificacion)
        {
            return _dbSet.FirstOrDefault(p => p.NroIdentificacion == nroIdentificacion);
        }
    }
}
