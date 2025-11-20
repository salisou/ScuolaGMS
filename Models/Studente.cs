namespace Models
{
    public class Studente
    {
        public int StudenteId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cognome { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Telefono { get; set; }

        public ICollection<Iscrizione> Iscrizione { get; set; } = new List<Iscrizione>();
        public ICollection<Presenza> Presenza { get; set; } = new List<Presenza>();
        public ICollection<Voto> Voti = new List<Voto>();
    }
}
