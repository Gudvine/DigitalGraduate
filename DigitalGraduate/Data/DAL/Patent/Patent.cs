namespace DigitalGraduate.Data.DAL.Patent;

/// <summary>
/// Представляет патент
/// </summary>
public class Patent
{
    /// <summary>
    /// Id патента
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Название патента
    /// </summary>
    public string Title { get; set; } = string.Empty;
    /// <summary>
    /// Дата выдачи патента
    /// </summary>
    public DateTime? IssueDate { get; set; }
}
