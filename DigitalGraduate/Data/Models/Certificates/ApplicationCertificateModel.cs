using System.ComponentModel.DataAnnotations;

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
        [Required]
        public string SpaceRequirement { get; set; } = string.Empty;
        /// <summary>
        /// Количество справок
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// Наличие гербовой печати
        /// </summary>
        public bool NeedOfficialSeal { get; set; }
        /// <summary>
        /// Id пользователя, заказывающего справку
        /// </summary>
        public int UserId { get; set; }
    }
}
