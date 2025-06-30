using CarSystem.Bll.DTOs.CarDto;
using CarSystem.Bll.DTOs.PersonDto;
using CarSystem.DataAccess.Entities;

namespace CarSystem.Api.Converter;

public static class Mappings
{
    private static object personCreatedto;

    public static PersonGetDto ConvertToUserGetDto(Person person)
    {
        return new PersonGetDto()
        {
            PersonId = person.PersonId,
            FirstName = person.FirstName,
            LastName = person.LastName,
            UserName = person.UserName,
            Password = person.Password,
            Email = person.Email,
            CarDtos = person.Cars == null ? new List<CarGetDto>() : person.Cars.Select(s=>ConvertToCarGetDto(s)).ToList(),
            //CarDtos = person.Cars == null ? new List<CarGetDto>() : person.Cars.Select(s => ConvertToCarGetDto(s)).ToList(),
        };
    }

    private static object ConvertToCarGetDto(object s)
    {
        throw new NotImplementedException();
    }

    public static Person ConvertToUser(PersonCreateDto personCreatedto)
    {
        return new Person()
        {
            FirstName = personCreatedto.FirstName,
            LastName = personCreatedto.LastName,
            UserName = personCreatedto.UserName,
            Password = personCreatedto.Password,
            Email = personCreatedto.Email,
        };
    }

    public static CarGetDto ConvertToSkillGetDto(Car car)
    {
        return new CarGetDto()
        {
            CarId = car.CarId,
            Brand = car.Brand,
            Name = car.Name,
            Description = car.Description,
            PersonId = car.PersonId,
           
        };
    }

    public static Car ConvertToSkill(CarCreateDto carCreateDto)
    {
        return new Car()
        {
            Brand = carCreateDto.Brand,
            Name = carCreateDto.Name,
            Description = carCreateDto.Description,
            PersonId = carCreateDto.PersonId,
        };
    }

    internal static object ConvertToPersonGetDto(object u)
    {
        throw new NotImplementedException();
    }
}
