using Hospital.Domain;
using System.Linq;

namespace Hospital.DataAccess.Repositories.Interfaces
{
    public interface IRasporedRepository : IGenericRepository<Raspored>
    {
        IQueryable<Raspored> GetAllRasporediWithTermini(int id);
    }
}
