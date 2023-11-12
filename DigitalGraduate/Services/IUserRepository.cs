using DigitalGraduate.Data.Models.Identity;

namespace DigitalGraduate.Services;

public interface IUserRepository
{
    Task<IEnumerable<ApiUser>> GetUsers();
    Task<ApiUser> GetUser(int id);
    Task<ApiUser> AddUser(ApiUser user);
    Task<ApiUser> UpdateUser(ApiUser user);
    void DeleteUser(int id);
}
