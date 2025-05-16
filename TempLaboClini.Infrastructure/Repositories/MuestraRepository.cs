using TempLaboClini.Domain.Entities;
using TempLaboClini.Infrastructure.Data;


namespace TempLaboClini.Infrastructure.Repositories
{
    public class MuestraRepository : GenericRepository<Muestra, Muestra>
    {
        public MuestraRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
