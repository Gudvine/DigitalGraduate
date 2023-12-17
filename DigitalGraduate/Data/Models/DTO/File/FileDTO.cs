namespace DigitalGraduate.Data.Models.DTO.File;

/// <summary>
/// DTO файла
/// </summary>
public class FileDTO
{
    /// <summary>
    /// Массив байтов с файлом
    /// </summary>
    public byte[]? Content { get; set; }
    /// <summary>
    /// Дата последнего изменения файла
    /// </summary>
    public DateTime? LastModification { get; set; }
    /// <summary>
    /// Тип файла
    /// </summary>
    public string FileType { get; set; } = string.Empty;
    /// <summary>
    /// Название файла
    /// </summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// Размер файла
    /// </summary>
    public int Size { get; set; }
}
