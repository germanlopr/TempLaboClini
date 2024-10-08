
using TempLaboClini.Domain.Entities;
using TempLaboClini.Infrastructure.Data;

namespace TempLaboClini.Infrastructure.Repositories
{
    public class PersonalLaboratorioRepository : BaseRepository<PersonalLaboratorio>
    {
        public PersonalLaboratorioRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
