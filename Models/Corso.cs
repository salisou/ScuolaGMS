namespace Models
{
    public class Corso
    {
        public int CorsoId { get; set; }
        public required string NomeCorso { get; set; } = string.Empty;
        public required string Descrizione { get; set; } = string.Empty;
        public int Crediti { get; set; }

        public ICollection<Iscrizione> Iscrizioni { get; set; } = new List<Iscrizione>();
        public ICollection<Lezione> Lezioni { get; set; } = new List<Lezione>();
        public ICollection<Valutazione> valutazioni { get; set; } = new List<Valutazione>();
    }
}
