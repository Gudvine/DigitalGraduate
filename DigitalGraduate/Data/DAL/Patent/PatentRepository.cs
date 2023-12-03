
using DigitalGraduate.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DigitalGraduate.Data.DAL.Patent;

/// <summary>
/// Класс-репозиторий для патентов
/// </summary>
public class PatentRepository : IRepository<Patent>
{
    private ApplicationDbContext _dbContext;

    public PatentRepository(ApplicationDbContext dbContext)
        => _dbContext = dbContext;

    /// <summary>
    /// Создает запись о патенте
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public async Task<Patent> Create(Patent item)
    {
        var result = await _dbContext.Patents.AddAsync(item);
        await _dbContext.SaveChangesAsync();

        return result.Entity;
    }

    /// <summary>
    /// Удаляет запись о патенте
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task Delete(int id)
    {
        var patentToDelete = _dbContext.Patents.FirstOrDefault(x => x.Id == id);

        if (patentToDelete is null)
            return;

        _dbContext.Patents.Remove(patentToDelete);
        await _dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Получает все записи о патентах
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Patent>> GetAll()
        => await _dbContext.Patents.ToListAsync();

    /// <summary>
    /// Получает запись о патенте на основе заданного Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Patent?> GetById(int id)
        => await _dbContext.Patents.FirstOrDefaultAsync(x => x.Id == id);

    /// <summary>
    /// Обновляет информацию о патенте
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public async Task<Patent?> Update(Patent item)
    {
        var result = await _dbContext.Patents.FirstOrDefaultAsync(x => x.Id == item.Id);

        if (result is null) 
            return null;

        result.Title = item.Title;
        result.IssueDate = item.IssueDate;

        await _dbContext.SaveChangesAsync();

        return result;
    }
}
