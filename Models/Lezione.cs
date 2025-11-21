namespace Models
{
    /// <summary>
    /// Lezione (Corso => Aula => Docente)
    /// </summary>
    public class Lezione
    {
        public int LezioneId { get; set; }
        public int CorsoId { get; set; }
        public Corso Corso { get; set; } = default!;
        public int DocenteId { get; set; }
        public Docente Docente { get; set; } = new Docente();
        public int AulaId { get; set; }
        public Aula Aula { get; set; } = default!;
        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }
        public string? Argomento { get; set; }

        public ICollection<Presenza> Presenze { get; set; } = [];
    }
}
