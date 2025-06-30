using CarSystem.Bll.DTOs.PersonDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.Bll.Services
{
    public interface IPersonService
    {
        Task<long> PostAsync(PersonCreateDto personCreateDto);
        Task<ICollection<PersonGetDto>> GetAllAsync();
        Task<bool> UpdateAsync(long personId, PersonUpdateDto personUpdateDto);
        Task<bool> DeleteAsync(long personId);
    }
}
