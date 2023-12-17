namespace DigitalGraduate.Data.DAL.CertificateApplication;

/// <summary>
/// Представляет заявку на оформление справки
/// </summary>
public class CertificateApplication
{
    /// <summary>
    /// Id заявки
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Куда предоставляется справка
    /// </summary>
    public string SpaceRequirement { get; set; } = string.Empty;
    /// <summary>
    /// Наличие гербовой печати
    /// </summary>
    public bool NeedOfficialSeal { get; set; }
    /// <summary>
    /// Количество справок для заказа
    /// </summary>
    public int Count { get; set; }
    /// <summary>
    /// Id студента, кому предоставляется справка
    /// </summary>
    public int UserId { get; set; }
}
