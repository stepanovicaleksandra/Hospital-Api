using Hospital.DataAccess.Repositories.Interfaces;
using Hospital.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Hospital.DataAccess.Repositories.Implementations
{
    public class ZakazivanjePregledaRepository : GenericRepository<ZakazivanjePregleda>, IZakazivanjePregledaRepository
    {
        public ZakazivanjePregledaRepository(ApplicationContext context) : base(context)
        {
        }

        public ZakazivanjePregleda GetZakazivnjePregledaWithEverything(int id)
        {
            // postaviti i Klijenta koji je vec dovucen kod pretrage svih
            return _context.ZakazivanjaPregleda.Include(x => x.TipPregleda)
                                               .Include(x => x.Termin)
                                               .ThenInclude(x => x.Raspored)
                                               .ThenInclude(x => x.Doktor).FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<ZakazivanjePregleda> GetAllZakazivanjePregledaWithKlijenti()
        {
            return _context.ZakazivanjaPregleda.Include(x => x.Klijent).Include(x => x.Termin);
        }

    }
}
