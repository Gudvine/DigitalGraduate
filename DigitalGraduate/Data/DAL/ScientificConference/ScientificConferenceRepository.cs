
using DigitalGraduate.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DigitalGraduate.Data.DAL.ScientificConference;

/// <summary>
/// Репозиторий научных конференций
/// </summary>
public class ScientificConferenceRepository : IRepository<ScientificConference>
{
    private ApplicationDbContext _dbContext;

    public ScientificConferenceRepository(ApplicationDbContext dbContext)
        => _dbContext = dbContext;

    /// <summary>
    /// Создает запись о научной конференции
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public async Task<ScientificConference> Create(ScientificConference item)
    {
        var result = await _dbContext.ScientificConferences.AddAsync(item);
        await _dbContext.SaveChangesAsync();

        return result.Entity;
    }

    /// <summary>
    /// Удаляет запись о научной конференции
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task Delete(int id)
    {
        var competitionToDelete = _dbContext.ScientificConferences.FirstOrDefault(x => x.Id == id);

        if (competitionToDelete is null)
            return;

        _dbContext.ScientificConferences.Remove(competitionToDelete);
        await _dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Получает все записи о научных конференциях
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<ScientificConference>> GetAll()
        => await _dbContext.ScientificConferences.ToListAsync();

    /// <summary>
    /// Получает запись о научной конференции по заданному Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<ScientificConference?> GetById(int id)
        => await _dbContext.ScientificConferences.FirstOrDefaultAsync(x => x.Id == id);

    /// <summary>
    /// Обновляет запись о научной конференции
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public async Task<ScientificConference?> Update(ScientificConference item)
    {
        var result = await _dbContext.ScientificConferences.FirstOrDefaultAsync(x => x.Id == item.Id);

        if (result is null)
            return null;

        result.Title = item.Title;
        result.Scale = item.Scale;
        result.Year = item.Year;
        result.IsWinner = item.IsWinner;
        result.Participation = item.Participation;

        await _dbContext.SaveChangesAsync();

        return result;
    }
}
