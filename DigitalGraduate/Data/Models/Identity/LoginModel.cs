using System.ComponentModel.DataAnnotations;

namespace DigitalGraduate.Data.Models.Identity;

/// <summary>
/// DTO-модель для контроллера логина в систему
/// </summary>
public class LoginModel
{
    [Required(ErrorMessage = "Введите логин пользователя")]
    public string Email { get; set; } = string.Empty;
    [Required(ErrorMessage = "Введите пароль")]
    public string Password { get; set; } = string.Empty;
}
