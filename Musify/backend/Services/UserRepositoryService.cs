using Microsoft.EntityFrameworkCore;
using Musify.Models;
using Musify.Repositories;

public class UserReposritoryService(MusifyContext ctx) : IUserRepository
{
    public async Task<User?> VerifyLogin(string username, string password)
    {   
        var users = await ctx.Users.ToListAsync();
        return users.Where(x => x.Username.ToLower().Equals(username.ToLower()) && x.Password.Equals(password)).FirstOrDefault();
    }

    public async Task<User?> GetByUsername(string username)
        =>  await ctx.Users.FirstOrDefaultAsync( u => u.Username == username);
    public async Task<User> Add(User user)
    {
        await ctx.AddAsync(user);
        await ctx.SaveChangesAsync();
        return user;
    }

    public async Task<User?> GetById(Guid id)
        =>  await ctx.Users.FindAsync(id);
}