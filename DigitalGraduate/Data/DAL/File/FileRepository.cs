
namespace DigitalGraduate.Data.DAL.File;

/// <summary>
/// Репозиторий для файлов
/// </summary>
public class FileRepository : IRepository<FileInstance>
{
    /// <summary>
    /// Создает новую запись о файле
    /// </summary>
    public void Create(FileInstance item)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Удаляет запись о файле
    /// </summary>
    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Получает все записи о файлах
    /// </summary>
    public IEnumerable<FileInstance> GetAll()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Получает запись о файле по заданному Id
    /// </summary>
    /// <param name="id"></param>
    public FileInstance GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Save()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Обновляет запись о файле
    /// </summary>
    /// <param name="item"></param>
    public FileInstance Update(FileInstance item)
    {
        throw new NotImplementedException();
    }
}
