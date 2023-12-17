
using DigitalGraduate.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DigitalGraduate.Data.DAL.Grant;

/// <summary>
/// Репозиторий грантов
/// </summary>
public class GrantRepository : IRepository<Grant>
{
    private ApplicationDbContext _dbContext;

    public GrantRepository(ApplicationDbContext dbContext)
        => _dbContext = dbContext;

    /// <summary>
    /// Создает запись о гранте
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public async Task<Grant> Create(Grant item)
    {
        var result = await _dbContext.Grants.AddAsync(item);
        await _dbContext.SaveChangesAsync();

        return result.Entity;
    }

    /// <summary>
    /// Удаляет запись о гранте
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task Delete(int id)
    {
        var grantToDelete = _dbContext.Grants.FirstOrDefault(x => x.Id == id);

        if (grantToDelete is null)
            return;

        _dbContext.Grants.Remove(grantToDelete);
        await _dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Получает все записи о грантах
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Grant>> GetAll()
        => await _dbContext.Grants.ToListAsync();

    /// <summary>
    /// Получает запись о гранте по заданному Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Grant?> GetById(int id)
        => await _dbContext.Grants.FirstOrDefaultAsync(x => x.Id == id);

    /// <summary>
    /// Обновляет информацию о гранте
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public async Task<Grant?> Update(Grant item)
    {
        var result = await _dbContext.Grants.FirstOrDefaultAsync(x => x.Id == item.Id);

        if (result is null)
            return null;

        result.Title = item.Title;
        result.GrantParticipation = item.GrantParticipation;

        await _dbContext.SaveChangesAsync();

        return result;
    }
}
