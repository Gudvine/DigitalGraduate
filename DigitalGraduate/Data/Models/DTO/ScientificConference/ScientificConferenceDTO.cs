namespace DigitalGraduate.Data.Models.DTO.ScientificConference;

/// <summary>
/// Представляет DTO научногой конференции
/// </summary>
public class ScientificConferenceDTO
{
    /// <summary>
    /// Id научной конференции
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Название конференции
    /// </summary>
    public string Title { get; set; } = string.Empty;
    /// <summary>
    /// Год
    /// </summary>
    public int Year { get; set; }
    /// <summary>
    /// Масштаб
    /// </summary>
    public string Level { get; set; } = string.Empty;
    /// <summary>
    /// Вид участия
    /// </summary>
    public string ParticipationOption { get; set; } = string.Empty;
    /// <summary>
    /// Победитель
    /// </summary>
    public bool IsWin { get; set; }
    /// <summary>
    /// Id пользователя, участника конференции
    /// </summary>
    public string? UserId { get; set; }
}
