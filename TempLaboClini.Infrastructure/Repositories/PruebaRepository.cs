using TempLaboClini.Domain.Entities;
using TempLaboClini.Infrastructure.Data;

namespace TempLaboClini.Infrastructure.Repositories
{
    public class PruebaRepository : BaseRepository<Prueba>
    {
        public PruebaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
