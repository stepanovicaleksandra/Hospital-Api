using Hospital.DataAccess.Repositories.Interfaces;
using Hospital.Domain;
using Hospital.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital.Service.Implementations
{
    public class RasporedService : IRasporedService
    {
        private readonly IRasporedRepository _rasporedRepository;

        public RasporedService(IRasporedRepository rasporedRepository)
        {
            _rasporedRepository = rasporedRepository;
        }
        public IQueryable<Raspored> GetAll(int doktorId)
        {
            return _rasporedRepository.GetAllRasporediWithTermini(doktorId);
        }
    }
}
