using System.ComponentModel.DataAnnotations;

namespace DigitalGraduate.Data.Models.DTO.Profile.Student;

/// <summary>
/// Представляет DTO для создания студента
/// </summary>
public class CreateStudentDTO
{
    /// <summary>
    /// Имя студента
    /// </summary>
    [Required(ErrorMessage = "Укажите имя")]
    public string? Name { get; set; }
    /// <summary>
    /// Фамилия студента
    /// </summary>
    [Required(ErrorMessage = "Укажите фамилию")]
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
