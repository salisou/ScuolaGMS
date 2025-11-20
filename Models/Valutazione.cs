namespace Models
{
    public class Valutazione
    {
        public int ValutazioneId { get; set; }
        public int CorsoId { get; set; }
        public Corso Corso { get; set; } = default!;
        public int DocenteId { get; set; }
        public Docente Docente { get; set; } = default!;
        public string Titolo { get; set; } = default!;
        public string Tipo { get; set; } = "Test"; // Test, Orale, Progetto
        public decimal PunteggioMassimo { get; set; } = 10.0m;
        public DateTime Data { get; set; }
        // Relazione
        public ICollection<Voto> Voti { get; set; } = new List<Voto>();
    }
}






