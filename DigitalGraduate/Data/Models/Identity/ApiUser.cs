using Microsoft.AspNetCore.Identity;

namespace DigitalGraduate.Data.Models.Identity;

public class ApiUser : IdentityUser
{
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string FirstName { get; set; } = string.Empty;
    /// <summary>
    /// Фамилия
    /// </summary>
    public string LastName { get; set; } = string.Empty;
    /// <summary>
    /// Отчество
    /// </summary>
    public string? Patronymic { get; set; }
    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime Birthday { get; set; }
    //public string? Role { get; set; }
}
