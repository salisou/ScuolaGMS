namespace Models
{
    public class Presenza
    {
        public int PresenzaId { get; set; }
        public int StudenteId { get; set; }
        public Studente Studente { get; set; } = new Studente();
        public int LezioneId { get; set; }
        public Lezione Lezione { get; set; } = new Lezione();
        public bool Stato { get; set; }
    }
}
