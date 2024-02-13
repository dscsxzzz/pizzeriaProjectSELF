using COLORADO.Data.Models;

namespace COLORADO.Services
{
    public interface IUserInterface
    {
        Task<List<User>> GetAll();
        Task<User>? Get(int id);
        Task<User>? GetByUsername(string username);
        Task<User>? GetByEmail(string email);
        Task<User> Add(User user);
        Task<User> Delete(int id);
        Task<User> Update(int id, User user);

    }
}
