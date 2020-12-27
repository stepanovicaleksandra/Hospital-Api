using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Domain
{
   public class Raspored:BaseEntity
    {
        public Raspored()
        {
            Termini = new HashSet<Termin>();
        }
        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }
        public Doktor Doktor { get; set; }
        public int DoktorId { get; set; }

        public virtual ICollection<Termin> Termini { get; set; }
    }
}
