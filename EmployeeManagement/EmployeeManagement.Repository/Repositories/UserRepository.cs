using EmployeeManagement.Dal;
using EmployeeManagement.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.Repositories;

public class UserRepository : IUserRepository
{
    private readonly MainContext MainContext;

    public UserRepository(MainContext mainContext)
    {
        MainContext = mainContext;
    }

    public async Task<long> InsertAsync(User user)
    {
        await MainContext.Users.AddAsync(user);
        await MainContext.SaveChangesAsync();
        return user.UserId;
    }


    public async Task<ICollection<User>> SelectAllAsync()
    {
        var users= await MainContext.Users.ToListAsync();
        return users;
        
    }

    public Task<User> SelectByIdAsync(long userId)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(User user)
    {
        MainContext.Users.Update(user);
        await MainContext.SaveChangesAsync();
    }
    public async Task DeleteAsync(User user)
    {
        await MainContext.Users.Remove(user);
        await MainContext.SaveChangesAsync();
        
    }
}
