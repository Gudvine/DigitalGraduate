namespace DigitalGraduate.Data.Models.DTO.Profile.Student;

/// <summary>
/// Представляет DTO студента
/// </summary>
public class StudentDTO
{
    /// <summary>
    /// Id студента
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Имя студента
    /// </summary>
    public string? Name { get; set; }
    /// <summary>
    /// Фамилия студента
    /// </summary>
    public string? LastName { get; set; }
    /// <summary>
    /// Отчество студента
    /// </summary>
    public string? Patronymic { get; set; }
    /// <summary>
    /// Дата рождения студента
    /// </summary>
    public DateTime? BirthDate { get; set; }
    /// <summary>
    /// Обучение на бюджете Да/Нет
    /// </summary>
    public bool IsBudget { get; set; }
    /// <summary>
    /// Курс
    /// </summary>
    public int Year { get; set; }
    /// <summary>
    /// Id пользователя, студента
    /// </summary>
    public string? UserId { get; set; }
}
