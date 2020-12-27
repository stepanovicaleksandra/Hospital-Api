using System;

namespace Hospital.Domain
{
    public class Termin : BaseEntity
    {
        public DateTime Datum { get; set; }
        public DateTime VremePocetka { get; set; }
        public DateTime VremeZavrsetka { get; set; }
        public bool Status { get; set; }
        public Raspored Raspored { get; set; }
        public int RasporedId { get; set; }
        public ZakazivanjePregleda ZakazivanjePregleda { get; set; }
        public int? ZakazivanjePregledaId { get; set; }

    }
}
