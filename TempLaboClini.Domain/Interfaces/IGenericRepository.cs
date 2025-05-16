using System.Linq.Expressions;
using TempLaboClini.Domain.Entities;


namespace TempLaboClini.Domain.Interfaces
{
    public interface IGenericRepository<TBase, TChild> where TBase : class where TChild : TBase
    {
        void Add(TChild entity);
        void Delete(long id);
        void Update(TChild entity);
        TChild GetById(long id);
        IEnumerable<TChild> GetAll();
        int Count(Expression<Func<TChild, bool>> predicate);
    }

}
