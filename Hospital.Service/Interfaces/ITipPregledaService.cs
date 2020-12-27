using Hospital.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Service.Interfaces
{
   public interface ITipPregledaService
    {
        IEnumerable<TipPregleda> GetAll();
    }
}
