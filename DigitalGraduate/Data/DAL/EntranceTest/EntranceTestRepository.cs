using DigitalGraduate.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DigitalGraduate.Data.DAL.EntranceTest;

/// <summary>
/// Репозиторий вступительных испытаний
/// </summary>
public class EntranceTestRepository : IRepository<EntranceTest>
{
    private ApplicationDbContext _dbContext;

    public EntranceTestRepository(ApplicationDbContext dbContext)
        => _dbContext = dbContext;

    /// <summary>
    /// Создает запись о вступительном испытании
    /// </summary>
    public async Task<EntranceTest> Create(EntranceTest item)
    {
        var result = await _dbContext.EntranceTests.AddAsync(item);
        await _dbContext.SaveChangesAsync();

        return result.Entity;
    }

    /// <summary>
    /// Удаляет запись о вступительном испытании
    /// </summary>
    public async Task Delete(int id)
    {
        var publicationToDelete = _dbContext.EntranceTests.Where(x => x.Id == id).FirstOrDefault();

        if (publicationToDelete is null)
            return;

        _dbContext.EntranceTests.Remove(publicationToDelete);
        await _dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Получает все записи о вступительных испытаниях
    /// </summary>
    public async Task<IEnumerable<EntranceTest>> GetAll()
        => await _dbContext.EntranceTests.ToListAsync();

    /// <summary>
    /// Получает запись о вступительном истпытании по заданному Id
    /// </summary>
    public async Task<EntranceTest?> GetById(int id)
        => await _dbContext.EntranceTests.FirstOrDefaultAsync(x => x.Id == id);

    /// <summary>
    /// Обновляет информацию в записи о вступительном испытании
    /// </summary>
    public async Task<EntranceTest?> Update(EntranceTest item)
    {
        var result = await _dbContext.EntranceTests.FirstOrDefaultAsync(x => x.Id == item.Id);

        if (result is null)
            return null;

        result.Title = item.Title;
        result.Grade = item.Grade;

        await _dbContext.SaveChangesAsync();

        return result;
    }
}
