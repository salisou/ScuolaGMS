namespace Models
{
    /// <summary>
    /// Iscrizione (STUDENTE => CORSO => CLASSE)
    /// </summary>
    public class Iscrizione
    {
        public int IscrizioneId { get; set; }
        public int StudenteId { get; set; }
        public Studente Studente { get; set; } = new();
        public int CorsoId { get; set; }
        public Corso Corso { get; set; } = default!;
        public int ClasseId { get; set; }
        public Classe Classe { get; set; } = default!;

        public string AnnoAccademico { get; set; } = default!;
    }
}
