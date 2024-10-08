using TempLaboClini.Domain.Entities;
using TempLaboClini.Infrastructure.Data;

namespace TempLaboClini.Infrastructure.Repositories
{
    public class FacturaRepository : BaseRepository<Factura>
    {
        public FacturaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
