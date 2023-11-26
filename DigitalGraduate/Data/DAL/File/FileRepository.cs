
using DigitalGraduate.Data.Context;

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
    /// Создает новую запись о файле
    /// </summary>
    public void Create(FileInstance item) 
        => _dbContext.Files.Add(item);

    /// <summary>
    /// Удаляет запись о файле
    /// </summary>
    public void Delete(int id)
    {
        var fileToDelete = GetById(id);

        if (fileToDelete is null)
            return;

        _dbContext.Files.Remove(fileToDelete);
    }

    /// <summary>
    /// Получает все записи о файлах
    /// </summary>
    public IEnumerable<FileInstance> GetAll()
        => _dbContext.Files.ToList();

    /// <summary>
    /// Получает запись о файле по заданному Id
    /// </summary>
    /// <param name="id"></param>
    public FileInstance? GetById(int id)
    {
        var file = _dbContext.Files.SingleOrDefault(f => f.Id == id);

        return file;
    }

    public void Save() 
        => _dbContext.SaveChanges();

    /// <summary>
    /// Обновляет запись о файле
    /// </summary>
    /// <param name="item"></param>
    public FileInstance Update(FileInstance item)
    {
        _dbContext.Files.Update(item);
        return item;
    }

    Task<FileInstance> IRepository<FileInstance>.Create(FileInstance item)
    {
        throw new NotImplementedException();
    }

    Task IRepository<FileInstance>.Delete(int id)
    {
        throw new NotImplementedException();
    }

    Task<IEnumerable<FileInstance>> IRepository<FileInstance>.GetAll()
    {
        throw new NotImplementedException();
    }

    Task<FileInstance> IRepository<FileInstance>.GetById(int id)
    {
        throw new NotImplementedException();
    }

    Task<FileInstance> IRepository<FileInstance>.Update(FileInstance item)
    {
        throw new NotImplementedException();
    }
}
