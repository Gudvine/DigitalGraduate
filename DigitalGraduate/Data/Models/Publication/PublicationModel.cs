using DigitalGraduate.Utils.JsonConverters;
using System.Text.Json.Serialization;

namespace DigitalGraduate.Data.Models.Publication;

/// <summary>
/// Представляет модель научной публикации
/// </summary>
public class PublicationModel
{
    /// <summary>
    /// Название публикации
    /// </summary>
    public string Title { get; set; } = string.Empty;
    /// <summary>
    /// Год публикации
    /// </summary>
    public int Year { get; set; }
    /// <summary>
    /// Тип статьи
    /// </summary>
    public string PublicationType { get; set; } = string.Empty;
    /// <summary>
    /// Издание
    /// </summary>
    public string Edition { get; set; } = string.Empty;
    /// <summary>
    /// Консультант
    /// </summary>
    public string Consultant { get; set; } = string.Empty;
    /// <summary>
    /// Файл публикации
    /// </summary>
    [JsonConverter(typeof(JsonToByteArrayConverter))]
    public byte[]? File { get; set; }
}
