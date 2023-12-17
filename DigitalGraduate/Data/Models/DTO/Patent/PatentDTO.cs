namespace DigitalGraduate.Data.Models.DTO.Patent;

/// <summary>
/// Представляет DTO патента
/// </summary>
public class PatentDTO
{
    /// <summary>
    /// Id патента
    /// </summary>
    public string Id { get; set; } = string.Empty;
    /// <summary>
    /// Название патента
    /// </summary>
    public string Title {  get; set; } = string.Empty;
    /// <summary>
    /// Дата подачи
    /// </summary>
    public string Date { get; set; } = string.Empty;
    /// <summary>
    /// Id пользователя, владельца патента
    /// </summary>
    public string UserId { get; set; } = string.Empty;
}
