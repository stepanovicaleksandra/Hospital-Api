using Hospital.DataAccess.Repositories.Interfaces;
using Hospital.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Hospital.DataAccess.Repositories.Implementations
{
   public class GenericRepository<T> : IGenericRepository<T> where T: BaseEntity
    {
        public ApplicationContext _context;

        public DbSet<T> table = null;

        public GenericRepository(ApplicationContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }

        public void Add(T obj)
        {
            table.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(T obj)
        {
            table.Remove(obj);
            _context.SaveChanges();
        }

        public T Get(object id)
        {
            return table.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return table;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
