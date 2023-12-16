using System.ComponentModel.DataAnnotations;

namespace DigitalGraduate.Data.Models.DTO.EntranceTest;

/// <summary>
/// Представляет DTO вступительного испытания
/// </summary>
public class EntranceTestDTO
{
    /// <summary>
    /// Id вступительного испытания
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Название вступительного испытания
    /// </summary>
    [Required(ErrorMessage = "Укажите название вступительного испытания")]
    public string? Title { get; set; }
    /// <summary>
    /// Оценка
    /// </summary>
    [Required(ErrorMessage = "Укажите оценку  за вступительное испытания")]
    public string? Grade { get; set; }
    /// <summary>
    /// Id пользователя, проходившего вступительное испытание
    /// </summary>
    public string? UserId { get; set; }
}
