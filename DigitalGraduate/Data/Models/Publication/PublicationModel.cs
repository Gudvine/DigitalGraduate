using DigitalGraduate.Utils.JsonConverters;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DigitalGraduate.Data.Models.Publication;

/// <summary>
/// Представляет модель научной публикации
/// </summary>
public class PublicationModel
{
    /// <summary>
    /// Id Публикации
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Название публикации
    /// </summary>
    [Required(ErrorMessage = "Название публикации обязательно к заполнению")]
    public string Title { get; set; } = string.Empty;
    /// <summary>
    /// Год публикации
    /// </summary>
    [Required(ErrorMessage = "Год публикации обязательно к заполнению")]
    public int Year { get; set; }
    /// <summary>
    /// Тип статьи
    /// </summary>
    [Required(ErrorMessage = "Тип публикации обязательно к заполнению")]
    public string PublicationType { get; set; } = string.Empty;
    /// <summary>
    /// Издание
    /// </summary>
    [Required(ErrorMessage = "Издание обязательно к заполнению")]
    public string Edition { get; set; } = string.Empty;
    /// <summary>
    /// Консультант
    /// </summary>
    [Required(ErrorMessage = "Консультант обязательно к заполнению")]
    public string Consultant { get; set; } = string.Empty;
    /// <summary>
    /// Файл публикации
    /// </summary>
    [JsonConverter(typeof(JsonToByteArrayConverter))]
    //[Required(ErrorMessage = "Приложите файл с публикацией")]
    public byte[]? File { get; set; } // позже переделать под Id файла
}
