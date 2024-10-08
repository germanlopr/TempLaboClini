using TempLaboClini.Domain.Entities;
using TempLaboClini.Infrastructure.Data;

namespace TempLaboClini.Infrastructure.Repositories
{
    public class MedicoRepository : BaseRepository<Medico>
    {
        public MedicoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
