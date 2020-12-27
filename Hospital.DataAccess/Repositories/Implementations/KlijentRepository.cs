using Hospital.DataAccess.Repositories.Interfaces;
using Hospital.Domain;

namespace Hospital.DataAccess.Repositories.Implementations
{
    public class KlijentRepository : GenericRepository<Klijent>, IKlijentRepository
    {
        public KlijentRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
