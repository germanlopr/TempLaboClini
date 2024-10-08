using TempLaboClini.Domain.Entities;
using TempLaboClini.Infrastructure.Data;

namespace TempLaboClini.Infrastructure.Repositories
{
    public class ExamenSolicitadoRepository : BaseRepository<ExamenSolicitado>
    {
        public ExamenSolicitadoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
