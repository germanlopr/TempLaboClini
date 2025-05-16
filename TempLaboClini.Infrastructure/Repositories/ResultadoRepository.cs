
using TempLaboClini.Domain.Entities;
using TempLaboClini.Infrastructure.Data;

namespace TempLaboClini.Infrastructure.Repositories
{
    public class ResultadoRepository : GenericRepository<Resultado, Resultado>
    {
        public ResultadoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
