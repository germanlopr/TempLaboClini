
using TempLaboClini.Domain.Entities;
using TempLaboClini.Infrastructure.Data;

namespace TempLaboClini.Infrastructure.Repositories
{
    public class AseguradoraRepository : GenericRepository<BaseEntity, Aseguradora>
    {
        public AseguradoraRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
