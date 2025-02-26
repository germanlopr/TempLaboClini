using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempLaboClini.Domain.Entities;

namespace TempLaboClini.Domain.Interfaces
{
    public interface IExamenRepository : IRepository<Examen>
    {
        IEnumerable<Muestra> GetMuestras(long examenId);
        Area GetArea(long examenId);
        IEnumerable<ValorReferencia> GetValoresReferencias(long examenId);
    }
}
