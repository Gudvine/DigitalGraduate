
using DigitalGraduate.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DigitalGraduate.Data.DAL.Dissertation;

/// <summary>
/// Представляет репозиторий диссертаций
/// </summary>
public class DissertationRepository : IRepository<Dissertation>
{
    private ApplicationDbContext _dbContext;

    public DissertationRepository(ApplicationDbContext dbContext)
        => _dbContext = dbContext;

    /// <summary>
    /// Создает запись о диссертации
    /// </summary>
    public async Task<Dissertation> Create(Dissertation item)
    {
        var result = await _dbContext.Dissertations.AddAsync(item);
        await _dbContext.SaveChangesAsync();

        return result.Entity;
    }

    /// <summary>
    /// Удаляет запись о диссертации
    /// </summary>
    public async Task Delete(int id)
    {
        var dissertationsToDelete = _dbContext.Dissertations.Where(x => x.Id == id).FirstOrDefault();

        if (dissertationsToDelete is null)
            return;

        _dbContext.Dissertations.Remove(dissertationsToDelete);
        await _dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Получает все записи о диссертациях
    /// </summary>
    public async Task<IEnumerable<Dissertation>> GetAll()
        => await _dbContext.Dissertations.ToListAsync();

    /// <summary>
    /// Получает запись о диссертации по заданному Id
    /// </summary>
    public async Task<Dissertation?> GetById(int id)
        => await _dbContext.Dissertations.FirstOrDefaultAsync(x => x.Id == id);

    /// <summary>
    /// Обновляет информацию в записи о диссертации
    /// </summary>
    public async Task<Dissertation?> Update(Dissertation item)
    {
        var result = await _dbContext.Dissertations.FirstOrDefaultAsync(x => x.Id == item.Id);

        if (result is null)
            return null;

        result.DefenseDate = item.DefenseDate;
        result.Status = item.Status;
        item.File = item.File;

        await _dbContext.SaveChangesAsync();

        return result;
    }
}
