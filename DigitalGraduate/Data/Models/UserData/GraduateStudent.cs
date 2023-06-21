using DigitalGraduate.Data.Models.Catalogs;
using DigitalGraduate.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace DigitalGraduate.Data.Models.UserData
{
    /// <summary>
    /// Представляет модель аспиранта/докторанта/соискателя
    /// </summary>
    public class GraduateStudent
    {
        public int Id { get; set; }
        public string ApiUserId { get; set; } = string.Empty;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Patronymic { get; set; } // Отчество
        public Gender Gender { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }
        // TODO: возможно передалать под отдельный тип
        public string? PassportData { get; set; }
        public string? PhoneNumber { get; set; }
        public Education Education { get; set; }
        public Institute? Institute { get; set; }
        public Department? Department { get; set; }
        public ScientificSpeciality? ScientificSpeciality { get; set; }
        public FormOfStudy FormOfStudy { get; set; }
        public BudgetForm BudgetForm { get; set; }
        public StudyStatus StudyStatus { get; set; }
    }
}
