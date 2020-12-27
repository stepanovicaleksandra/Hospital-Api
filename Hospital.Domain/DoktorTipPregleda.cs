using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Domain
{
   public class DoktorTipPregleda:BaseEntity
    {
        public Doktor Doktor { get; set; }
        public int DoktorId { get; set; }
        public TipPregleda TipPregleda { get; set; }
        public int TipPregledaId { get; set; }
    }
}
