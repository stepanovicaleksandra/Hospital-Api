using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hospital.Models
{
   public class CreateZakazivanjePregledaDto
    {
        public int RasporedId { get; set; }
        public int TerminId { get; set; }
        public int KlijentId { get; set; }
        public int TipPregledaId { get; set; }

        [StringLength(1000)]
        public string Napomena { get; set; }
    }
}
