using DigitalGraduate.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DigitalGraduate.Data.DAL.Publication;

/// <summary>
/// Репозиторий публикаций
/// </summary>
public class PublicationRepository : IRepository<Publication>
{
    private ApplicationDbContext _dbContext;

    public PublicationRepository(ApplicationDbContext dbContext)
        => _dbContext = dbContext;

    /// <summary>
    /// Создает запись о публикации
    /// </summary>
    /// <param name="item"></param>
    public async Task<Publication> Create(Publication item)
    {
        var result = await _dbContext.Publications.AddAsync(item);
        await _dbContext.SaveChangesAsync();

        return result.Entity;
    }

    /// <summary>
    /// Удаляет запись о публикации
    /// </summary>
    /// <param name="id"></param>
    public async Task Delete(int id)
    {
        var publicationToDelete = _dbContext.Publications.Where(x => x.Id == id).FirstOrDefault();

        if (publicationToDelete is null)
            return;

        _dbContext.Publications.Remove(publicationToDelete);
        await _dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Получает все записи о публикациях
    /// </summary>
    public async Task<IEnumerable<Publication>> GetAll()
        => await _dbContext.Publications.ToListAsync();

    /// <summary>
    /// Возвращает запись о публикации на основе заданного id
    /// </summary>
    /// <param name="id"></param>
    public async Task<Publication?> GetById(int id)
        => await _dbContext.Publications.FirstOrDefaultAsync(x => x.Id == id);

    /// <summary>
    /// Обновляет информацию в записи о публикации
    /// </summary>
    /// <param name="item"></param>
    public async Task<Publication?> Update(Publication item)
    {
        var result = await _dbContext.Publications.FirstOrDefaultAsync(x => x.Id == item.Id);

        if (result is null)
            return null;

        result.Name = item.Name;
        result.PublishYear = item.PublishYear;

        await _dbContext.SaveChangesAsync();

        return result;
    }
}
