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
    public string Title { get; set; } = string.Empty;
    /// <summary>
    /// Тип публикации
    /// </summary>
    public string PublicationType { get; set; } = string.Empty;
    /// <summary>
    /// Год публикации
    /// </summary>
    public int PublishYear { get; set; }
    /// <summary>
    /// Издание
    /// </summary>
    public string Edition { get; set; } = string.Empty;
    /// <summary>
    /// Id файла научной публикации
    /// </summary>
    public int FileId { get; set; }
    /// <summary>
    /// ФИО консультанта
    /// </summary>
    public string Adviser { get; set; } = string.Empty;
    /// <summary>
    /// Id пользователя, автора публикации
    /// </summary>
    public string? UserId { get; set; }
}
