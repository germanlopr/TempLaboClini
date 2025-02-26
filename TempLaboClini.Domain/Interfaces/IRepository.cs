using System.Linq.Expressions;
using TempLaboClini.Domain.Entities;


namespace TempLaboClini.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(long id);
        void Update(T entity);
        int Count(Expression<Func<T, bool>> where);
        T GetById(long id);
     //   IEnumerable<T> FindBy(QueryParam<T> QueryParam);
        IEnumerable<T> GetAll();   //TODO mejorar GetAll(int pageIndex = 0, int pageSize = 10);

    }
}
