namespace Dtos.IscrizioneDtos
{
    /// <summary>
    /// BASE DTO – proprietà comuni
    /// </summary>
    public class IscrizioneBase
    {
        public int StudenteId { get; set; }
        public int CorsoId { get; set; }
        public int ClasseId { get; set; }
        public string AnnoAccademico { get; set; } = default!;
    }
}
