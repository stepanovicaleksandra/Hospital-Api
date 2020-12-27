using Hospital.DataAccess.Repositories.Implementations;
using Hospital.DataAccess.Repositories.Interfaces;
using Hospital.Domain;
using Hospital.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Service.Implementations
{
    public class TipPregledaService : ITipPregledaService
    {
        private readonly ITipPregledaRepository _tipPregledaRepository;

        public TipPregledaService(ITipPregledaRepository tipPregledaRepository)
        {
            _tipPregledaRepository = tipPregledaRepository;
        }
        public IEnumerable<TipPregleda> GetAll()
        {
           return _tipPregledaRepository.GetAllTipPregledaWithDoktor();
        }
    }
}
