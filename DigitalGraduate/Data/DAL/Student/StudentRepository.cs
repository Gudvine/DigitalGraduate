
using DigitalGraduate.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DigitalGraduate.Data.DAL.Student;

/// <summary>
/// Репозиторий студентов
/// </summary>
public class StudentRepository : IRepository<Student>
{
    private readonly ApplicationDbContext _dbContext;

    public StudentRepository(ApplicationDbContext dbContext)
        => _dbContext = dbContext;

    /// <summary>
    /// Создает запись о студенте
    /// </summary>
    public async Task<Student> Create(Student item)
    {
        var result = await _dbContext.Students.AddAsync(item);
        await _dbContext.SaveChangesAsync();

        return result.Entity;
    }

    /// <summary>
    /// Удаляет запись о студенте
    /// </summary>
    public async Task Delete(int id)
    {
        var studentToDelete = _dbContext.Students.FirstOrDefault(x => x.Id == id);

        if (studentToDelete is null)
            return;

        _dbContext.Students.Remove(studentToDelete);
        await _dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Возвращает список всех студентов
    /// </summary>
    public async Task<IEnumerable<Student>> GetAll()
        => await _dbContext.Students.ToListAsync();

    /// <summary>
    /// Возвращает студента по заданному Id
    /// </summary>
    public async Task<Student?> GetById(int id)
        => await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);

    /// <summary>
    /// Обновляет запись о студенте
    /// </summary>
    public async Task<Student?> Update(Student item)
    {
        var result = await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == item.Id);

        if (result is null)
            return null;

        result.Name = item.Name;
        result.LastName = item.LastName;
        result.Patronymic = item.Patronymic;
        result.BirthDate = item.BirthDate;
        result.Year = item.Year;
        result.IsBudget = item.IsBudget;

        await _dbContext.SaveChangesAsync();

        return result;
    }
}
