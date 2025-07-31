using Identity.Dal;
using Identity.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace Identity.Repository.Repositories;

public class UserRepository : IUserRepository
{
    private readonly MainContext MainContext;

    public UserRepository(MainContext mainContext)
    {
        MainContext = mainContext;
    }

    public async Task CreateAsync(User user, string password)
    {
        user.Password = password;
        await MainContext.Users.AddAsync(user);
        await MainContext.SaveChangesAsync();

    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await MainContext.Users.FirstOrDefaultAsync(u => u.Email == email);

    }

    public async Task UpdateAsync(User user)
    {
        MainContext.Users.Update(user);
        await MainContext.SaveChangesAsync();

    }
}
