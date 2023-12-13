namespace DigitalGraduate.Data.DAL.ScientificCompetition;

/// <summary>
/// Представляет модель научного конкурса
/// </summary>
public class ScientificCompetition
{
    /// <summary>
    /// Id научного конкурса
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Название конкурса
    /// </summary>
    public string Title { get; set; } = string.Empty;
    /// <summary>
    /// Год научного конкурса
    /// </summary>
    public int Year { get; set; }
    /// <summary>
    /// Результат
    /// </summary>
    public string Result { get; set; }
    /// <summary>
    /// Id пользователя, участника конкурса
    /// </summary>
    public string? UserId { get; set; }
}
