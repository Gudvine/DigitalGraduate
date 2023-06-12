using System.ComponentModel.DataAnnotations;

namespace DigitalGraduate.Data.Models.Identity
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Введите логин пользователя")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; } = string.Empty;
    }
}
