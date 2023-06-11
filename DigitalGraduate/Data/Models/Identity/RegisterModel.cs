using System.ComponentModel.DataAnnotations;

namespace DigitalGraduate.Data.Models.Identity
{
    /// <summary>
    /// Модель регистрации пользователя в системе.
    /// Содержит поля, необходимые для регистрации пользователя
    /// </summary>
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не введен Email-адрес")]
        [EmailAddress(ErrorMessage = "Введите корректный Email")]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Login { get; set; } = string.Empty;
        [Required(ErrorMessage = "Не введен пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        [Required(ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
