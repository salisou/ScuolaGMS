namespace Dtos.StudenteDtos
{
    /// <summary>
    /// UPDATE DTO - include l'ID
    /// </summary>
    public class StudenteUpdateDto : StudenteBase
    {
        public int StudenteId { get; set; }
    }
}
