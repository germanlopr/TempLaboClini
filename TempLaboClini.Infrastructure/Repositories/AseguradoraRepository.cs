
using TempLaboClini.Domain.Entities;
using TempLaboClini.Infrastructure.Data;

namespace TempLaboClini.Infrastructure.Repositories
{
    public class AseguradoraRepository : BaseRepository<Aseguradora>
    {
        public AseguradoraRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
