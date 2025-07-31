using Identity.Dal.Entities;

namespace Identity.Repository.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task CreateAsync(User user, string password);
        Task UpdateAsync(User user);
    }
}