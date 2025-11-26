namespace Dtos.ValutazioneDtos
{
    /// <summary>
    /// BASE DTO - contiene le proprietà comuni
    /// </summary>
    public class ValutazioneBase
    {
        public int CorsoId { get; set; }
        public int DocenteId { get; set; }
        public string Titolo { get; set; } = string.Empty;
        public string Tipo { get; set; } = "Test"; 
        public decimal PunteggioMassimo { get; set; } = 10.0m;
        public DateTime Data { get; set; }
    }
}
