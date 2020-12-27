using System;
using System.Collections.Generic;
using System.Text;
using Hospital.Domain;

namespace Hospital.Service.Interfaces
{
   public interface IKlijentService
    {
        IEnumerable<Klijent> GetAll();
     
    }
}
