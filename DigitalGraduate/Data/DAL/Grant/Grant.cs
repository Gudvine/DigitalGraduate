using DigitalGraduate.Data.Models.Enums;

namespace DigitalGraduate.Data.DAL.Grant;

/// <summary>
/// Представляет модель "Гранты"
/// </summary>
public class Grant
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public GrantParticipation GrantParticipation { get; set; }
}
