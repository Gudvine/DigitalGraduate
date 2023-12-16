namespace DigitalGraduate.Data.DAL.EntranceTest;

/// <summary>
/// Представляет модель вствупительного испытания
/// </summary>
public class EntranceTest
{
    /// <summary>
    /// Id вступительного испытания
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Название вступительного испытания
    /// </summary>
    public string? Title { get; set; }
    /// <summary>
    /// Оценка
    /// </summary>
    public string? Grade { get; set; }
    /// <summary>
    /// Id пользователя, проходившего вступительное испытание
    /// </summary>
    public string? UserId { get; set; }
}
