namespace DigitalGraduate.Data.DAL;

public interface IRepository<TData> where TData : class
{
    Task<IEnumerable<TData>> GetAll();
    Task<TData> GetById(int id);
    Task<TData> Create(TData item);
    Task<TData> Update(TData item);
    Task Delete(int id);
}
