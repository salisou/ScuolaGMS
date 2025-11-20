namespace Models
{
    public class Voto
    {
        public int VotoId { get; set; }
        public int StudenteId { get; set; }
        public Studente Studente { get; set; } = new();
        public int ValutazioneId { get; set; }
        public Valutazione Valutazione { get; set; } = new();
        public decimal Punteggio { get; set; }
        public string? Commento { get; set; }

    }
}
