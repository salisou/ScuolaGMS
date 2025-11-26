namespace Dtos.VotoDtos
{
    /// <summary>
    /// BASE DTO – proprietà comuni
    /// </summary>
    public class VotoBase
    {
        public int StudenteId { get; set; } 
        public int ValutazioneId { get; set; }
        public decimal Punteggio { get; set; }
        public string? Commento { get; set; }
    }
}
