using Hospital.Domain;
using System.Collections.Generic;

namespace Hospital.DataAccess.Repositories.Interfaces
{
    public interface IZakazivanjePregledaRepository : IGenericRepository<ZakazivanjePregleda>
    {
        IEnumerable<ZakazivanjePregleda> GetAllZakazivanjePregledaWithKlijenti();

        ZakazivanjePregleda GetZakazivnjePregledaWithEverything(int id);

    }
}
