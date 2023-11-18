namespace DigitalGraduate.Data.DAL.Publication;

/// <summary>
/// Представляет научную публикацию
/// </summary>
public class Publication
{
    /// <summary>
    /// Id научной публикации
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Название научной публикации
    /// </summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// Год публикации
    /// </summary>
    public int PublishYear { get; set; }
    /// <summary>
    /// Id файла научной публикации
    /// </summary>
    public int FileId { get; set; }
}
