

using TempLaboClini.Domain.Entities;
using TempLaboClini.Infrastructure.Data;

namespace TempLaboClini.Infrastructure.Repositories
{
    public class SolicitudExamenRepository : BaseRepository<SolicitudExamen>
    {
        public SolicitudExamenRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
