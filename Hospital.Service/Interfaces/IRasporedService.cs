using Hospital.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital.Service.Interfaces
{
   public interface IRasporedService
    {
        IQueryable<Raspored> GetAll(int id);
    }
}
