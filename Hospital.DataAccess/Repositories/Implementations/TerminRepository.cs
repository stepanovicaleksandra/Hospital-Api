using Hospital.DataAccess.Repositories.Interfaces;
using Hospital.Domain;

namespace Hospital.DataAccess.Repositories.Implementations
{
    public class TerminRepository : GenericRepository<Termin>, ITerminRepository
    {
        public TerminRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
