namespace Models
{
    public class Aula
    {
        public int AulaId { get; set; }
        public string Codice { get; set; } = default!;
        public int Capienza { get; set; }
        public ICollection<Lezione> Lezioni { get; set; } = new List<Lezione>();
    }
}
