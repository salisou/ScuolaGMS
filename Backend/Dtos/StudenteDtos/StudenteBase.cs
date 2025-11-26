namespace Dtos.StudenteDtos
{
    // BASE DTO - contiene le proprietà comuni
    public class StudenteBase
    {
        public string Nome { get; set; } = string.Empty;
        public string Cognome { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Telefono { get; set; }
    }
}
