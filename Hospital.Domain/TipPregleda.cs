
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Domain
{
   public class TipPregleda:BaseEntity
    {
        public TipPregleda()
        {
            Zakazivanja = new HashSet<ZakazivanjePregleda>();
            DoktorTipPregleda = new HashSet<DoktorTipPregleda>();
        }
        public string Naziv { get; set; }
        public string Napomena { get; set; }
        public virtual ICollection<ZakazivanjePregleda> Zakazivanja { get; set; }
        public virtual ICollection<DoktorTipPregleda> DoktorTipPregleda { get; set; }

    }
}
