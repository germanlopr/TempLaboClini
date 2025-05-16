using TempLaboClini.Domain.Entities;
using TempLaboClini.Infrastructure.Data;

namespace TempLaboClini.Infrastructure.Repositories
{
    public class MedicoRepository : GenericRepository<Persona, Medico>
    {
        public MedicoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
