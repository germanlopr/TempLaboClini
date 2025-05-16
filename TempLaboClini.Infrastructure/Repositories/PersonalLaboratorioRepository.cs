
using TempLaboClini.Domain.Entities;
using TempLaboClini.Infrastructure.Data;

namespace TempLaboClini.Infrastructure.Repositories
{
    public class PersonalLaboratorioRepository : GenericRepository<PersonalLaboratorio, PersonalLaboratorio>
    {
        public PersonalLaboratorioRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
