using CarSystem.DataAccess;
using CarSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.Repository.Repositories;

public class PersonRepository : IPersonReporitory
{
    private readonly MainContext MainContext;
    public PersonRepository(MainContext mainContext)
    {
        MainContext=mainContext;
    }

    public async Task<long> InsertAsync(Person person)
    {
        await MainContext.Persons.AddAsync(person);
        await MainContext.SaveChangesAsync();
        return person.PersonId;
    }

    public async Task<ICollection<Person>> SelectAllAsync()
    {
        var persons = await MainContext.Persons
            .Include(u => u.Cars)
            .ToListAsync();

        return persons;
    }

    public async Task<Person> SelectByIdAsync(long personId)
    {
        var person = await MainContext.Persons.FirstOrDefaultAsync(u => u.PersonId == personId);

        if (person == null)
        {
            throw new Exception($"User with id : {personId} not found");
        }

        await MainContext.Entry(person).Collection(u => u.Cars).LoadAsync();

        return person;
    }

    public async Task UpdateAsync(Person person)
    {
        MainContext.Persons.Update(person);
        await MainContext.SaveChangesAsync();
    }
    public async Task DeleteAsync(Person person)
    {
        MainContext.Persons.Remove(person);
        await MainContext.SaveChangesAsync();
    }
}
