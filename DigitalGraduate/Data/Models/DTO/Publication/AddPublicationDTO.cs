using DigitalGraduate.Data.Models.DTO.File;
using System.ComponentModel.DataAnnotations;

namespace DigitalGraduate.Data.Models.DTO.Publication;

/// <summary>
/// Представляет DTO для создания публикации
/// </summary>
public class AddPublicationDTO
{
    /// <summary>
    /// Название публикации
    /// </summary>
    [Required(ErrorMessage = "Укажите название публикации")]
    public string Title { get; set; } = string.Empty;
    /// <summary>
    /// Год издания публикации
    /// </summary>
    [Required(ErrorMessage = "Укажите год публикации")]
    public string Year { get; set; } = string.Empty;
    /// <summary>
    /// Тип публикации
    /// </summary>
    [Required(ErrorMessage = "Укажите тип публикации")]
    public string PublicationType { get; set; } = string.Empty;
    /// <summary>
    /// Издание
    /// </summary>
    [Required(ErrorMessage = "Укажите издание публикации")]
    public string Edition { get; set; } = string.Empty;
    /// <summary>
    /// ФИО консультанта
    /// </summary>
    [Required(ErrorMessage = "Укажите консультанта публикации")]
    public string Consultant { get; set; } = string.Empty;
    /// <summary>
    /// Id пользователя, автора статьи
    /// </summary>
    public string UserId { get; set; } = string.Empty;
    /// <summary>
    /// Файл публикации
    /// </summary>
    [Required(ErrorMessage = "Загрузите файл публикации")]
    public FileDTO? File { get; set; }
}
