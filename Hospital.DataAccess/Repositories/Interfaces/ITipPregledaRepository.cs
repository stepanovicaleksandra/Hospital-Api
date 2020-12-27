using Hospital.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.DataAccess.Repositories.Interfaces
{
    public interface ITipPregledaRepository:IGenericRepository<TipPregleda>
    {
        IEnumerable<TipPregleda> GetAllTipPregledaWithDoktor();

    }
}
