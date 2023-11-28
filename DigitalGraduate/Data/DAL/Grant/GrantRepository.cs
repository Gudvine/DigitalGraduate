
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
    public Task<Grant> Create(Grant item)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Удаляет запись о гранте
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task Delete(int id)
    {
        throw new NotImplementedException();
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
    public Task<Grant?> GetById(int id)
        => _dbContext.Grants.FirstOrDefaultAsync(x => x.Id == id);

    /// <summary>
    /// Обновляет информацию о гранте
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public Task<Grant> Update(Grant item)
    {
        throw new NotImplementedException();
    }
}
