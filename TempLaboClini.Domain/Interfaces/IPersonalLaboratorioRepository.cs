using TempLaboClini.Domain.Entities;

namespace TempLaboClini.Domain.Interfaces
{
    public interface IPersonalLaboratorioRepository : IGenericRepository<BaseEntity, PersonalLaboratorio>
    {
        IEnumerable<PersonalLaboratorio> GetByArea(string area);
    }
}
