namespace Dtos
{
    public class PresenzaDto
    {
        public int Id { get; set; }
        public int StudenteId { get; set; }
        public int LezioneId { get; set; }
        public bool Presente { get; set; }
    }

    public class PresenzaCreateDto
    {
        public int StudenteId { get; set; }
        public int LezioneId { get; set; }
        public bool Presente { get; set; }
    }

    public class PresenzaUpdateDto
    {
        public int Id { get; set; }
        public int StudenteId { get; set; }
        public int LezioneId { get; set; }
        public bool Presente { get; set; }
    }
}
