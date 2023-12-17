namespace DigitalGraduate.Data.DAL.ScientificConference;

/// <summary>
/// Представляет научную конференцию
/// </summary>
public class ScientificConference
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
    public string Scale { get; set; } = string.Empty;
    /// <summary>
    /// Вид участия
    /// </summary>
    public string Participation {  get; set; } = string.Empty;
    /// <summary>
    /// Победитель
    /// </summary>
    public bool IsWinner { get; set; }
    /// <summary>
    /// Id пользователя, участника конференции
    /// </summary>
    public string? UserId { get; set; }
}
