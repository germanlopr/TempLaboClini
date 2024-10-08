using TempLaboClini.Domain.Entities;
using TempLaboClini.Infrastructure.Data;

namespace TempLaboClini.Infrastructure.Repositories
{
    public class ExamenRepository : BaseRepository<Examen>
    {
        public ExamenRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
