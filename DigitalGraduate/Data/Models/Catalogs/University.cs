namespace DigitalGraduate.Data.Models.Catalogs
{
    /// <summary>
    /// Представляет справочник "Учебные заведения (вузы)"
    /// </summary>
    public class University
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ShortName { get; set; }
        public bool IsRegion { get; set; }
    }
}
