using DigitalGraduate.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DigitalGraduate.Data.DAL.CertificateApplication;

/// <summary>
/// Репозиторий заявок на справку
/// </summary>
public class CertificateApplicationRepository : IRepository<CertificateApplication>
{
    private ApplicationDbContext _dbContext;

    public CertificateApplicationRepository(ApplicationDbContext dbContext)
        => _dbContext = dbContext;

    /// <summary>
    /// Создает запись о заявке на справку
    /// </summary>
    /// <param name="item"></param>
    public async Task<CertificateApplication> Create(CertificateApplication item)
    {
        var result = await _dbContext.CertificateApplications.AddAsync(item);
        await _dbContext.SaveChangesAsync();

        return result.Entity;
    }

    /// <summary>
    /// Удаляет запись о заявке на справку
    /// </summary>
    /// <param name="id"></param>
    public async Task Delete(int id)
    {
        var certificateAppToDelete = _dbContext.CertificateApplications.FirstOrDefault(x => x.Id == id);

        if (certificateAppToDelete is null)
            return;

        _dbContext.CertificateApplications.Remove(certificateAppToDelete);
        await _dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Возвращает все записи о заявках на справку
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<CertificateApplication>> GetAll()
        => await _dbContext.CertificateApplications.ToListAsync();

    /// <summary>
    /// Возвращает запись о заявке на справку по заданному Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<CertificateApplication?> GetById(int id)
        => await _dbContext.CertificateApplications.FirstOrDefaultAsync(x => x.Id == id);

    /// <summary>
    /// Обновляет информацию о заявке на справку
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public async Task<CertificateApplication?> Update(CertificateApplication item)
    {
        var result = await _dbContext.CertificateApplications.FirstOrDefaultAsync(x => x.Id == item.Id);

        if (result is null)
            return null;

        result.ProvideTo = item.ProvideTo;
        result.WithOfficialSeal = item.WithOfficialSeal;
        result.StudentId = item.StudentId;
        result.Count = item.Count;

        await _dbContext.SaveChangesAsync();

        return result;
    }
}
