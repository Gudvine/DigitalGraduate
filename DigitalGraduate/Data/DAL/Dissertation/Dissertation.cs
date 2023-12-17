using DigitalGraduate.Data.DAL.File;
using DigitalGraduate.Data.Models.Enums;

namespace DigitalGraduate.Data.DAL.Dissertation;

/// <summary>
/// Представляет диссертацию
/// </summary>
public class Dissertation
{
    /// <summary>
    /// Id диссертации
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Дата защиты
    /// </summary>
    public string? DefenseDate { get; set; }
    /// <summary>
    /// Статус диссертации
    /// </summary>
    public DissertationStatus Status { get; set; }
    /// <summary>
    /// Файл диссертации
    /// </summary>
    public FileInstance? File { get; set; }
    /// <summary>
    /// Id пользователя
    /// </summary>
    public string? UserId { get; set; }
}
