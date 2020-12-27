using Hospital.Domain;
using System.Collections.Generic;

namespace Hospital.DataAccess.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();

        T Get(object id);

        void Add(T obj);

        void Update(T obj);

        void Delete(T obj);

        void SaveChanges();
    }
}
