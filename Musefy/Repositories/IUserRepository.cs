namespace Musify.Repositories;

using System.Threading.Tasks;
using Musify.Models;

public interface IUserRepository
{
    Task<User?> Get(string username, string password);
}