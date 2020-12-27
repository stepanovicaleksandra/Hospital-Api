using Hospital.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Service.Interfaces
{
   public interface IZakazivanjePregledaService
    {
        IEnumerable<ZakazivanjePregleda> GetAll();

        ZakazivanjePregleda Get(int id);

        ServiceResult<ZakazivanjePregleda> Add(ZakazivanjePregleda zakazivanjePregleda);

        ServiceResult<ZakazivanjePregleda> Update(ZakazivanjePregleda zakazivanjePregleda);

        ServiceResult<ZakazivanjePregleda> Delete(ZakazivanjePregleda zakazivanjePregleda);
    }
}
