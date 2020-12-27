using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Domain
{
   public class ZakazivanjePregleda:BaseEntity
    {
        public string Napomena { get; set; }
        public Klijent Klijent { get; set; }
        public int KlijentId { get; set; }
        public TipPregleda TipPregleda { get; set; }
        public int TipPregledaId { get; set; }
        public Termin Termin { get; set; }
        public int TerminId { get; set; }
        public Raspored Raspored { get; set; }
        public int RasporedId { get; set; }

    }
}
