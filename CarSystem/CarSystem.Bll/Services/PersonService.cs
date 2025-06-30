using CarSystem.Api.Converter;
using CarSystem.Bll.DTOs.PersonDto;
using CarSystem.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.Bll.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonReporitory PersonReporitory;
        private readonly IValidator<PersonCreateDto> Validator;
        public PersonService(IPersonRepository personRepository, IValidator<PersonCreateDto> validator)
        {
            PersonRepository = personRepository;
            Validator = validator;
        }

        public async Task<ICollection<PersonGetDto>> GetAllAsync()
        {
            var persons = await PersonRepository.SelectAllAsync();
            var personsDto = persons.Select(u => Mappings.ConvertToPersonGetDto(u)).ToList();
            return personsDto;
        }

        public async Task<long> PostAsync(PersonCreateDto personCreateDto)
        {

            var result = Validator.Validate(personCreateDto);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            var person = Mappings.ConvertToUser(personCreateDto);
            var personId = await PersonRepository.InsertAsync(person);
            return personId;
        }

        public async Task<bool> UpdateAsync(long personId, PersonUpdateDto personUpdateDto)
        {
            var person = await PersonRepository.SelectByIdAsync(personId);
            if (person == null)
                return false;

            person.FirstName = personUpdateDto.FirstName;
            person.LastName = personUpdateDto.LastName;
            person.UserName = personUpdateDto.UserName;
            person.Password = personUpdateDto.Password;
            person.Email = personUpdateDto.Email;

            await PersonRepository.UpdateAsync(person);
            return true;
        }
        public async Task<bool> DeleteAsync(long personId)
        {
            var person = await PersonRepository.SelectByIdAsync(personId);
            if (person == null)
                return false;

            await PersonRepository.DeleteAsync(person);
            return true;
        }
    }

  
}
