using Hospital.DataAccess.Repositories.Interfaces;
using Hospital.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital.DataAccess.Repositories.Implementations
{
    public class RasporedRepository : GenericRepository<Raspored>, IRasporedRepository
    {
        public RasporedRepository(ApplicationContext context) : base(context)
        {
        }

        public IQueryable<Raspored> GetAllRasporediWithTermini(int doktorId)
        {
            return _context.Rasporedi.Where(x => x.DoktorId == doktorId).Include(x => x.Termini);
        }
    }
}
