namespace Models
{
    public class Classe
    {
        public int ClasseId { get; set; }
        public DateTime Anno { get; set; }
        public string Sezione { get; set; } = string.Empty;
        public ICollection<Iscrizione> Iscrizioni { get; set; } = new List<Iscrizione>();
    }
}
