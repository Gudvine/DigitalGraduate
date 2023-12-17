namespace DigitalGraduate.Data.DAL.Certification;

/// <summary>
/// Представляет аттестацию
/// </summary>
public class Certification
{
    /// <summary>
    /// Id аттестации
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Семестр
    /// </summary>
    public string? Semester { get; set; }
    /// <summary>
    /// Результат - Аттестатция Да/Нет
    /// </summary>
    public bool Result { get; set; }
    /// <summary>
    /// Id пользователя
    /// </summary>
    public string? UserId { get; set; }
}
