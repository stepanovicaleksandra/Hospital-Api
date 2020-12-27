using System.Collections.Generic;

namespace Hospital.Domain
{
   public class Klijent:BaseEntity
    {
        public Klijent()
        {
            Zakazivanja = new HashSet<ZakazivanjePregleda>();
        }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int Jmbg { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public virtual ICollection<ZakazivanjePregleda> Zakazivanja { get; set; }
    }
}
