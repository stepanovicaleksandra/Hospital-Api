using Hospital.DataAccess.Repositories.Interfaces;
using Hospital.Domain;
using Hospital.Service.Interfaces;
using System.Collections.Generic;

namespace Hospital.Service.Implementations
{
    public class ZakazivanjePregledaService : IZakazivanjePregledaService
    {
        private readonly IZakazivanjePregledaRepository _zakazivanjePregledaRepository;
        public ZakazivanjePregledaService(IZakazivanjePregledaRepository zakazivanjePregledaRepository)
        {
            _zakazivanjePregledaRepository = zakazivanjePregledaRepository;
        }

        public ServiceResult<ZakazivanjePregleda> Add(ZakazivanjePregleda zakazivanjePregleda)
        {
     
            _zakazivanjePregledaRepository.Add(zakazivanjePregleda);
            _zakazivanjePregledaRepository.SaveChanges();
            return new ServiceResult<ZakazivanjePregleda>(true, "Zakazivanje pregleda je uspesno obavljeno.", zakazivanjePregleda);

        }

        public ServiceResult<ZakazivanjePregleda> Delete(ZakazivanjePregleda zakazivanjePregleda)
        {
            _zakazivanjePregledaRepository.Delete(zakazivanjePregleda);
            _zakazivanjePregledaRepository.SaveChanges();
            return new ServiceResult<ZakazivanjePregleda>(true, "Zakazivanje pregleda je uspesno izbrisano.", zakazivanjePregleda);
        }

        public ZakazivanjePregleda Get(int id)
        {
            return _zakazivanjePregledaRepository.GetZakazivnjePregledaWithEverything(id);
         
        }

        public IEnumerable<ZakazivanjePregleda> GetAll()
        {
            return _zakazivanjePregledaRepository.GetAllZakazivanjePregledaWithKlijenti();
        }

        public ServiceResult<ZakazivanjePregleda> Update(ZakazivanjePregleda zakazivanjePregleda)
        {
            _zakazivanjePregledaRepository.Update(zakazivanjePregleda);
            _zakazivanjePregledaRepository.SaveChanges();
            return new ServiceResult<ZakazivanjePregleda>(true, "Zakazivanje pregleda je uspesno izmenjeno.", zakazivanjePregleda);
        }
    }
}
