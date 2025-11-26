namespace Models
{
    public class Docente
    {
        public int DocenteId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cognome { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public ICollection<Lezione> Lezioni { get; set; } = [];
        public ICollection<Valutazione> Valutazioni { get; set; } = [];
    }
}



