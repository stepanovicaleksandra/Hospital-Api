using System.Collections.Generic;

namespace Hospital.Domain
{
    public class Doktor:BaseEntity
    {
        public Doktor()
        {
            Rasporedi = new HashSet<Raspored>();
            DoktorTipPregleda = new HashSet<DoktorTipPregleda>();
        }

        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int Jmbg { get; set; }
        public string Specijalnost { get; set; }
        public virtual ICollection<Raspored> Rasporedi { get; set; }
        public virtual ICollection<DoktorTipPregleda> DoktorTipPregleda { get; set; }
    }
}
