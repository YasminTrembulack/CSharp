using Microsoft.EntityFrameworkCore;
using Musify.Models;
using Musify.Repositories;

public class UserReposritoryService(MusifyContext ctx) : IUserRepository
{
    public async Task<User?> Get(string username, string password)
    {   
        if(username is null || password is null)
            return null;
        var users = await ctx.Users.ToListAsync();
        List<User> user = [];
        user.Add(new User{ Username = "Yasmin", Password = "1234", BirthDate = "06/12/2005", Role = "ADM"  });

        return user.Where(x => x.Username.ToLower().Equals(username.ToLower()) && x.Password.Equals(password)).FirstOrDefault();
    }
}