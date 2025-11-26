namespace Dtos.LezioneDtos
{
    public class LezioneBase
    {
        public int CorsoId { get; set; }
        public int DocenteId { get; set; }
        public int AulaId { get; set; }

        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }

        public string? Argomento { get; set; }

    }
}
