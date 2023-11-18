namespace DigitalGraduate.Data.DAL;

public interface IRepository<TData> where TData : class
{
    IEnumerable<TData> GetAll();
    TData GetById(int id);
    void Create(TData item);
    TData Update(TData item);
    void Delete(int id);
    void Save();
}
