
using DigitalGraduate.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DigitalGraduate.Data.DAL.ScientificCompetition;

/// <summary>
/// Репозиторий научных конкурсов
/// </summary>
public class ScientificCompetitionRepository : IRepository<ScientificCompetition>
{
    private ApplicationDbContext _dbContext;

    public ScientificCompetitionRepository(ApplicationDbContext dbContext)
        => _dbContext = dbContext;

    /// <summary>
    /// Создает запись о научном конкурсе
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public async Task<ScientificCompetition> Create(ScientificCompetition item)
    {
        var result = await _dbContext.ScientificCompetitions.AddAsync(item);
        await _dbContext.SaveChangesAsync();

        return result.Entity;
    }

    /// <summary>
    /// Удаляет запись о научном конкурсе
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task Delete(int id)
    {
        var competitionToDelete = _dbContext.ScientificCompetitions.FirstOrDefault(x => x.Id == id);
        
        if (competitionToDelete is null)
            return;

        _dbContext.ScientificCompetitions.Remove(competitionToDelete);
        await _dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Получает все записи о научных конкурсах
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<ScientificCompetition>> GetAll()
        => await _dbContext.ScientificCompetitions.ToListAsync();

    /// <summary>
    /// Получает запись о научном конкурсе по заданному Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<ScientificCompetition?> GetById(int id)
        => await _dbContext.ScientificCompetitions.FirstOrDefaultAsync(x => x.Id == id);

    /// <summary>
    /// Обновляет запись о научном конкурсе
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public async Task<ScientificCompetition?> Update(ScientificCompetition item)
    {
        var result = await _dbContext.ScientificCompetitions.FirstOrDefaultAsync(x => x.Id == item.Id);

        if (result is null)
            return null;

        result.Title = item.Title;
        result.Result = item.Result;
        result.Year = item.Year;

        await _dbContext.SaveChangesAsync();

        return result;
    }
}
