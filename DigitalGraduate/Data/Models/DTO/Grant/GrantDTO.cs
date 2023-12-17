using System.ComponentModel.DataAnnotations;

namespace DigitalGraduate.Data.Models.DTO.Grant;

/// <summary>
/// DTO для гранта
/// </summary>
public class GrantDTO
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Введите название гранта")]
    public string Title { get; set; } = string.Empty;
    public string? Participation { get; set; }
    public string? UserId { get; set; }
}
