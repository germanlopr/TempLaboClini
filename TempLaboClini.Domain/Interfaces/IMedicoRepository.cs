using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempLaboClini.Domain.Entities;

namespace TempLaboClini.Domain.Interfaces
{
    public interface IMedicoRepository : IGenericRepository<BaseEntity, Medico>
    {
        Task<Medico> GetByCodigoMedicoAsync(string codigoMedico);
        Task<IEnumerable<Medico>> GetByEspecialidadAsync(string especialidad);
    }
}
