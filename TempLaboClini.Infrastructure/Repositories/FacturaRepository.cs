using TempLaboClini.Domain.Entities;
using TempLaboClini.Infrastructure.Data;

namespace TempLaboClini.Infrastructure.Repositories
{
    public class FacturaRepository : GenericRepository<BaseEntity, Factura>
    {
        public FacturaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
