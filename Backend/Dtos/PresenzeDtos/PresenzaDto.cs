using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.PresenzeDtos
{
    public class PresenzaDto : PresenzaBase
    {
        public int PresenzaId { get; set; }
        public string Studente { get; set; } = string.Empty;
        public string Lezione { get; set; } = string.Empty;
    }
}
