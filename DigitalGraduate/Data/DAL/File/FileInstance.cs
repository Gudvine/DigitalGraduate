namespace DigitalGraduate.Data.DAL.File;

/// <summary>
/// Представляет объект файла
/// </summary>
public class FileInstance
{
    /// <summary>
    /// Id файла
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Название файла
    /// </summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// Содержание файла (непосредственно сам файл)
    /// </summary>
    public byte[]? Content { get; set; }
    /// <summary>
    /// Размер файла
    /// </summary>
    public long Size { get; set; }
}
