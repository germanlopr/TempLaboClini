using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempLaboClini.Domain.Entities;

namespace TempLaboClini.Domain.Interfaces
{
    public interface ISolicitudExamenRepository : IRepository<SolicitudExamen>
    {
        Task<IEnumerable<SolicitudExamen>> GetByPacienteIdAsync(long pacienteId);
        Task<IEnumerable<SolicitudExamen>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        int GetNextNroRegistro();
        IEnumerable<SolicitudExamen> ObtenerOrdenesPendientes();
        void ActualizarEstado(SolicitudExamen solicitudExamen);
        SolicitudExamen GetEstado(Guid Id);
    }
}
