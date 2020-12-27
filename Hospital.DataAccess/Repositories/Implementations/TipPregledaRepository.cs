using Hospital.DataAccess.Repositories.Interfaces;
using Hospital.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.DataAccess.Repositories.Implementations
{
    public class TipPregledaRepository : GenericRepository<TipPregleda>, ITipPregledaRepository
    {
        public TipPregledaRepository(ApplicationContext context) : base(context)
        {
        }

        public IEnumerable<TipPregleda> GetAllTipPregledaWithDoktor()
        {
            return _context.TipoviPregleda.Include(x => x.DoktorTipPregleda).ThenInclude(x => x.Doktor);
        }
    }
}
