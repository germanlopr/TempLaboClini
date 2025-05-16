using TempLaboClini.Domain.Entities;
using TempLaboClini.Domain.Interfaces;
using TempLaboClini.Infrastructure.Data;

namespace TempLaboClini.Infrastructure.Repositories
{
    public class ExamenSolicitadoRepository : GenericRepository<BaseEntity, ExamenSolicitado>, IExamenSolicitadoLineRepository
    {
        public ExamenSolicitadoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
