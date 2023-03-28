namespace DigitalGraduate.Data.Models.Catalogs
{
    /// <summary>
    /// Представляет справочник "Мероприятия вуза"
    /// </summary>
    public class UniversityEvent
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Score { get; set; }
    }
}
