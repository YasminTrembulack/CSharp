namespace Musify.Repositories;

using System.Threading.Tasks;
using Musify.Models;

public interface IUserRepository
{
    Task<User?> VerifyLogin(string username, string password);
    Task<User?> GetByUsername(string username);
    Task<User?> GetById(Guid id);
    Task<User> Add(User user);
}