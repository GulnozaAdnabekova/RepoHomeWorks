using CarSystem.DataAccess.Configurations;
using CarSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.DataAccess;

public class MainContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Car> Cars { get; set; }

    public MainContext(DbContextOptions<MainContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new CarConfigurations());
        modelBuilder.ApplyConfiguration(new PersonConfigurations());
    }

}
