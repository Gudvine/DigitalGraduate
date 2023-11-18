using DigitalGraduate.Data.Context;

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
    public void Create(Publication item) 
        => _dbContext.Publications.Add(item);

    /// <summary>
    /// Удаляет запись о публикации
    /// </summary>
    /// <param name="id"></param>
    public void Delete(int id)
    {
        var publicationToDelete = _dbContext.Publications.Where(x => x.Id == id).FirstOrDefault();

        if (publicationToDelete is null)
            return;

        _dbContext.Publications.Remove(publicationToDelete);
    }

    /// <summary>
    /// Получает все записи о публикациях
    /// </summary>
    public IEnumerable<Publication> GetAll() 
        => _dbContext.Publications.ToList();

    /// <summary>
    /// Возвращает запись о публикации на основе заданного id
    /// </summary>
    /// <param name="id"></param>
    public Publication? GetById(int id)
        => _dbContext.Publications.Where(x => x.Id == id).FirstOrDefault();

    /// <summary>
    /// Обновляет информацию в записи о публикации
    /// </summary>
    /// <param name="item"></param>
    public Publication Update(Publication item)
    {
        _dbContext.Publications.Update(item);
        return item;
    }

    public async void Save()
        => await _dbContext.SaveChangesAsync();
}
