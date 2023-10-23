using DigitalGraduate.Data.Models.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DigitalGraduate.Services;

/// <summary>
/// Представляет набор методов для работы с JWT авторизацией
/// </summary>
public class AuthenticationService
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<ApiUser> _userManager;

    public AuthenticationService(IConfiguration configuration, UserManager<ApiUser> userManager)
    {
        _configuration = configuration;
        _userManager = userManager;
    }

    /// <summary>
    /// Генерирует и возвращает JWT токен для заданного ApiUser
    /// </summary>
    public async Task<string> GenerateToken(ApiUser user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = _configuration["JwtSettings:Key"];

        var roles = await _userManager.GetRolesAsync(user);
        var authClaims = new List<Claim>()
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email!),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, roles.FirstOrDefault()),
                };

        ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                    authClaims,
                    JwtBearerDefaults.AuthenticationScheme);

        var now = DateTime.Now;

        var jwtToken = new JwtSecurityToken(
                notBefore: now,
                issuer: _configuration["JwtSettings:Issuer"]!,
                audience: _configuration["JwtSettings:Audience"]!,
                claims: claimsIdentity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(10)),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(tokenKey)), SecurityAlgorithms.HmacSha256));

        return tokenHandler.WriteToken(jwtToken);
    }
}
