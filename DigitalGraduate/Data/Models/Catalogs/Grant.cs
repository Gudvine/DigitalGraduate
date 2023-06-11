using DigitalGraduate.Data.Models.Enums;

namespace DigitalGraduate.Data.Models.Catalogs
{
    /// <summary>
    /// Представляет модель "Гранты"
    /// </summary>
    public class Grant
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public GrantParticipation GrantParticipation { get; set; }
    }
}
