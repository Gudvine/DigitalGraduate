namespace DigitalGraduate.Data.Models.Identity;

/// <summary>
/// Модель пользователя 
/// </summary>
public class UserDTO
{
    /// <summary>
    /// Id пользователя
    /// </summary>
    public string? Id { get; set; }
    /// <summary>
    /// Имя пользователя (Email)
    /// </summary>
    public string? UserName { get; set; }
    /// <summary>
    /// Роль пользователя в системе
    /// </summary>
    public string? UserRole { get; set; }
    /// <summary>
    /// Jwt-токен авторизации
    /// </summary>
    public string? Token { get; set; }
}
