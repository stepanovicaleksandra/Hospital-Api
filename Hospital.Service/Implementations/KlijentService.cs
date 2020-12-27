using Hospital.DataAccess.Repositories.Interfaces;
using Hospital.Domain;
using Hospital.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;


namespace Hospital.Service.Implementations
{
    public class KlijentService : IKlijentService
    {
        private readonly IKlijentRepository _klijentRepository;

        public KlijentService(IKlijentRepository klijentRepository)
        {
            _klijentRepository = klijentRepository;
        }
        public IEnumerable<Klijent> GetAll()
        {
            return _klijentRepository.GetAll();
        }
    }
}
