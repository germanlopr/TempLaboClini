using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TempLaboClini.Domain.Entities;
using TempLaboClini.Domain.Interfaces;
using TempLaboClini.Infrastructure.Data;

namespace TempLaboClini.Infrastructure.Repositories
{
    public class ExamenRepository : GenericRepository<BaseEntity, Examen>, IExamenRepository
    {
        public ExamenRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Muestra> GetMuestras(long examenId)
        {
            var examen = _dbSet.Include(e => e.ExamenesMuestras)
                               .ThenInclude(em => em.Muestra)
                               .FirstOrDefault(e => e.Id == examenId);

            if (examen != null)
            {
                return examen.ExamenesMuestras.Select(em => em.Muestra).ToList();
            }

            return Enumerable.Empty<Muestra>();
        }

        public Area GetArea(long examenId)
        {
            var examen = _dbSet.Include(e => e.Area)
                               .FirstOrDefault(e => e.Id == examenId);

            if (examen != null)
            {
                return examen.Area;
            }

            return null;
        }

        public IEnumerable<ValorReferencia> GetValoresReferencias(long examenId)
        {
            var examen = _dbSet.Include(e => e.Pruebas)
                               .ThenInclude(p => p.ValoresReferencia)
                               .FirstOrDefault(e => e.Id == examenId);

            if (examen != null)
            {
                return examen.Pruebas.SelectMany(p => p.ValoresReferencia).ToList();
            }

            return Enumerable.Empty<ValorReferencia>();
        }

    }
}
