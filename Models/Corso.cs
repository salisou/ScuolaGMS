namespace Models
{
    public class Corso
    {
        public int CorsoId { get; set; }
        public required string NomeCorso { get; set; } = string.Empty;
        public required string Descrizione { get; set; } = string.Empty;
        public int Crediti { get; set; }

        public ICollection<Iscrizione> Iscrizioni { get; set; } = [];
        public ICollection<Lezione> Lezioni { get; set; } = [];
        public ICollection<Valutazione> Valutazioni { get; set; } = [];
    }
}
