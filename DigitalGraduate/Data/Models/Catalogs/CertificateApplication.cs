using DigitalGraduate.Data.Models.UserData;

namespace DigitalGraduate.Data.Models.Catalogs
{
    /// <summary>
    /// Представляет заявку на оформление справки
    /// </summary>
    public class CertificateApplication
    {
        public int Id { get; set; }
        public string ProvideTo { get; set; } = string.Empty;
        public bool WithOfficialSeal { get; set; }
        public int Count { get; set; }
        public GraduateStudent Student { get; set; }
    }
}
