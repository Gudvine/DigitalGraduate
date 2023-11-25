
using DigitalGraduate.Data.Context;

namespace DigitalGraduate.Data.DAL.CertificateApplication;

public class CertificateApplicationRepository : IRepository<CertificateApplication>
{
    private ApplicationDbContext _dbContext;

    public CertificateApplicationRepository(ApplicationDbContext dbContext)
        => _dbContext = dbContext;

    /// <summary>
    /// Создает запись о заявке на справку
    /// </summary>
    /// <param name="item"></param>
    public void Create(CertificateApplication item)
        => _dbContext.CertificateApplications.Add(item);

    /// <summary>
    /// Удаляет запись о заявке на справку
    /// </summary>
    /// <param name="id"></param>
    public void Delete(int id)
    {
        var certificateAppToDelete = _dbContext.CertificateApplications.FirstOrDefault(x => x.Id == id);

        if (certificateAppToDelete is null)
            return;

        _dbContext.CertificateApplications.Remove(certificateAppToDelete);
    }

    public IEnumerable<CertificateApplication> GetAll()
        => _dbContext.CertificateApplications.ToList();

    public CertificateApplication? GetById(int id)
        => _dbContext.CertificateApplications.Where(x => x.Id == id).FirstOrDefault();

    public async void Save()
        => await _dbContext.SaveChangesAsync();

    public CertificateApplication Update(CertificateApplication item)
    {
        _dbContext.CertificateApplications.Update(item);
        return item;
    }
}
