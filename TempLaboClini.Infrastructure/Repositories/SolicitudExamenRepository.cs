

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TempLaboClini.Domain.Entities;
using TempLaboClini.Domain.Interfaces;
using TempLaboClini.Infrastructure.Data;

namespace TempLaboClini.Infrastructure.Repositories
{
    public class SolicitudExamenRepository : GenericRepository<SolicitudExamen, SolicitudExamen>, ISolicitudExamenRepository
    {
        public SolicitudExamenRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void ActualizarEstado(SolicitudExamen solicitudExamen)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SolicitudExamen>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SolicitudExamen>> GetByPacienteIdAsync(long pacienteId)
        {
            throw new NotImplementedException();
        }

        public SolicitudExamen GetEstado(Guid Id)
        {
            throw new NotImplementedException();
        }

        public int GetNextNroRegistro()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SolicitudExamen> ObtenerOrdenesPendientes()
        {
            throw new NotImplementedException();
        }
    }
}
