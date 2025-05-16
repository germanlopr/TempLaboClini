

using TempLaboClini.Domain.Entities;
using TempLaboClini.Infrastructure.Data;

namespace TempLaboClini.Infrastructure.Repositories
{
    public class ValorReferenciaRepository : GenericRepository<ValorReferencia, ValorReferencia>
    {
        public ValorReferenciaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
