using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.LezioneDtos
{
    public class LezioneDtos : LezioneBase
    {
        public int LezioneId { get; set; }

        public string CorsoNome { get; set; } = string.Empty;
        public string DocenteNome { get; set; } = string.Empty;
        public string AulaCodice { get; set; } = string.Empty;
    }
}
