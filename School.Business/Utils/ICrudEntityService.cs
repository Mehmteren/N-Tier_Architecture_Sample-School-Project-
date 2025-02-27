using Core.Business.DTOs.Student;
using Core.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Utils
{
    public interface ICrudEntityService
    {
        public interface ICrudEntityService<TEntityGetDto, TEntityCreateDto, TEntityUpdateDto>
            where TEntityGetDto : IEntityGetDto, new()
            where TEntityCreateDto : IDto, new()
            where TEntityUpdateDto : IDto, new()
        {
            Task<TEntityGetDto> AddAsync(TEntityCreateDto input);
            Task<TEntityGetDto?> UpdateAsync(Guid id, TEntityUpdateDto input);
            Task DeleteByIdAsync(Guid id);
            Task<TEntityGetDto> GetByIdAsync(Guid id);
            Task<ICollection<TEntityGetDto>> GetAllAsync();

        }

        
    }
}
