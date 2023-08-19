using System.IdentityModel.Tokens.Jwt;

namespace DigitalGraduate.Services;

/// <summary>
/// Представляет набор методов для работы с JWT авторизацией
/// </summary>
public class AuthenticationService
{
    private readonly IConfiguration _configuration;

    public AuthenticationService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// Генерирует и возвращает JWT токен (дописать комент)
    /// </summary>
    public JwtSecurityToken GenerateToken()
    {
        var now = DateTime.Now;

        //JwtSecurityToken token = new(
        //    notBefore: now,
        //    issuer: );d

        return null!;
    }
}
