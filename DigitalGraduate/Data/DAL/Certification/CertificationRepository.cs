using DigitalGraduate.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DigitalGraduate.Data.DAL.Certification;

/// <summary>
/// Репозиторий аттестаций
/// </summary>
public class CertificationRepository : IRepository<Certification>
{
    private ApplicationDbContext _dbContext;

    public CertificationRepository(ApplicationDbContext dbContext)
        => _dbContext = dbContext;

    /// <summary>
    /// Создает запись об аттестации
    /// </summary>
    public async Task<Certification> Create(Certification item)
    {
        var result = await _dbContext.Certifications.AddAsync(item);
        await _dbContext.SaveChangesAsync();

        return result.Entity;
    }

    /// <summary>
    /// Удаляет запись об аттестации
    /// </summary>
    public async Task Delete(int id)
    {
        var certificationToDelete = _dbContext.Certifications.Where(x => x.Id == id).FirstOrDefault();

        if (certificationToDelete is null)
            return;

        _dbContext.Certifications.Remove(certificationToDelete);
        await _dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Получает все записи об аттестациях
    /// </summary>
    public async Task<IEnumerable<Certification>> GetAll()
        => await _dbContext.Certifications.ToListAsync();

    /// <summary>
    /// Получает запись об аттестации по заданному Id
    /// </summary>
    public async Task<Certification?> GetById(int id)
        => await _dbContext.Certifications.FirstOrDefaultAsync(x => x.Id == id);

    /// <summary>
    /// Обновляет информацию в записи об аттестации
    /// </summary>
    public async Task<Certification?> Update(Certification item)
    {
        var result = await _dbContext.Certifications.FirstOrDefaultAsync(x => x.Id == item.Id);

        if (result is null)
            return null;

        result.Result = item.Result;
        result.Semester = item.Semester;

        await _dbContext.SaveChangesAsync();

        return result;
    }
}
