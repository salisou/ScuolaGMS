namespace Models
{
    public class Studente
    {
        public int StudenteId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cognome { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Telefono { get; set; }

        public ICollection<Iscrizione> Iscrizione { get; set; } = [];
        public ICollection<Presenza> Presenze { get; set; } = [];
        public ICollection<Voto> Voti = [];
    }
}
