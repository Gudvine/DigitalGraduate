using DigitalGraduate.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DigitalGraduate.Data.DAL.File;

/// <summary>
/// Репозиторий для файлов
/// </summary>
public class FileRepository : IRepository<FileInstance>
{
    private ApplicationDbContext _dbContext;

    public FileRepository(ApplicationDbContext dbContext) 
        => _dbContext = dbContext;

    /// <summary>
    /// Создает запись о файле
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public async Task<FileInstance> Create(FileInstance item)
    {
        var result = await _dbContext.Files.AddAsync(item);
        await _dbContext.SaveChangesAsync();

        return result.Entity;
    }

    /// <summary>
    /// Удаляет запись о файле
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task Delete(int id)
    {
        var competitionToDelete = _dbContext.Files.FirstOrDefault(x => x.Id == id);

        if (competitionToDelete is null)
            return;

        _dbContext.Files.Remove(competitionToDelete);
        await _dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Получает все записи о файлах
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<FileInstance>> GetAll()
        => await _dbContext.Files.ToListAsync();

    /// <summary>
    /// Получает запись о файле по заданному Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<FileInstance?> GetById(int id)
        => await _dbContext.Files.FirstOrDefaultAsync(x => x.Id == id);

    /// <summary>
    /// Обновляет запись о файле
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public async Task<FileInstance?> Update(FileInstance item)
    {
        var result = await _dbContext.Files.FirstOrDefaultAsync(x => x.Id == item.Id);

        if (result is null)
            return null;

        result.Name = item.Name;
        result.Size = item.Size;
        result.Content = item.Content;

        await _dbContext.SaveChangesAsync();

        return result;
    }
}
