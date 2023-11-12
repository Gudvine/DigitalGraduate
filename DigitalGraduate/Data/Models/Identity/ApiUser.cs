using Microsoft.AspNetCore.Identity;

namespace DigitalGraduate.Data.Models.Identity;

public class ApiUser : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Surname { get; set; }
}
