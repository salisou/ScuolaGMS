namespace Dtos.CorsoDtos
{
    public class CorsoBase
    {
        public required string NomeCorso { get; set; } = string.Empty;
        public required string Descrizione { get; set; } = string.Empty;
        public int Crediti { get; set; }
    }

}
