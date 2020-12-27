using Hospital.DataAccess.Repositories.Interfaces;
using Hospital.Domain;

namespace Hospital.DataAccess.Repositories.Implementations
{
    public class DoktorRepository : GenericRepository<Doktor>, IDoktorRepository
    {
        public DoktorRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
