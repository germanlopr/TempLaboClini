

namespace TempLaboClini.Infrastructure.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using TempLaboClini.Domain.Interfaces;
    using TempLaboClini.Infrastructure.Data;

    public class GenericRepository<TBase, TChild> : IGenericRepository<TBase, TChild>
            where TBase : class
            where TChild : class, TBase 
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<TChild> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TChild>();
        }

        public void Add(TChild entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                _context.SaveChanges();
            }
        }

        public void Update(TChild entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public TChild GetById(long id) => _dbSet.Find(id);

        public IEnumerable<TChild> GetAll() => _dbSet.ToList();

        public int Count(Expression<Func<TChild, bool>> predicate) => _dbSet.Count(predicate);
    }

}
