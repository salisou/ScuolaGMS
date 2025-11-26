using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.PresenzeDtos
{
    public class PresenzaBase
    {
        public int StudenteId { get; set; }
        public int LezioneId { get; set; }
        public bool Stato { get; set; }
    }
}
