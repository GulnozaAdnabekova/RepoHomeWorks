using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSystem.DataAccess.Entities;

namespace CarSystem.DataAccess.Configurations;

public class CarConfigurations : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable("Car");
        builder.HasKey(u => u.CarId);

        builder.Property(u => u.Brand).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Name).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Description).IsRequired(false).HasMaxLength(250);
        
}
}