using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Commander.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CommanderContext _context;
        private readonly DbSet<T> _entities;

        public Repository(CommanderContext context)
        {
            _context = context;
            _entities = context.Set<T>();

        }
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public T Get(long id)
        {
            return _entities.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public void Insert(T entity)
        {
            _entities.Add(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(T entity)
        {
            _entities.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}