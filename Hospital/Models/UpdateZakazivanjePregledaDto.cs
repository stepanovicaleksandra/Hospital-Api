using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Models
{
    public class UpdateZakazivanjePregledaDto
    {
        public int Id { get; set; }
        public int RasporedId { get; set; }
        public int TerminId { get; set; }
        public string Napomena { get; set; }
    }
}
