using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.IscrizioneDtos
{
    public class IscrizioneDto: IscrizioneBase
    {
        public string StudenteNome { get; set; } = "";
        public string CorsoNome { get; set; } = "";
        public string ClasseSezione { get; set; } = "";
    }
}
