using core.data.Context;
using core.data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly BookServiceContext _context;
        private readonly DbSet<T> _dbSet;

        public IUnitOfWork UnitOfWork => _context;

        public Repository(BookServiceContext context)
        {
            _context = context;
            _dbSet= _context.Set<T>();
        }

        public void Add(T entity)
            => _context.Add(entity);

        public void Remove(T entity)
         => _context.Remove(entity);

        public void Update(T entity)
           => _context.Update(entity);


    }
}
