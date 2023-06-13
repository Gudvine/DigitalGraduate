namespace DigitalGraduate.Data.Models.Certificates
{
    /// <summary>
    /// Представляет модель заявки на офрмление справок студенту
    /// </summary>
    public class ApplicationCertificateModel
    {
        /// <summary>
        /// В какую организацию предоставляется
        /// </summary>
        public string Type { get; set; } = string.Empty;
        /// <summary>
        /// Количество справок
        /// </summary>
        public string Count { get; set; } = string.Empty;
        /// <summary>
        /// Обозначает делать ли справку с гербовой печатью
        /// </summary>
        public bool WithOfficialSeal { get; set; }
    }
}
