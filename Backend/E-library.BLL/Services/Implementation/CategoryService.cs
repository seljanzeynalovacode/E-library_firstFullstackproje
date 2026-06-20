using AutoMapper;
using E_library.BLL.DTOs;
using E_library.BLL.Services.Interface;
using E_library.DAL.Entities;
using E_library.DAL.Repository;

namespace E_library.BLL.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _repository;
        private readonly IMapper _mapper;

        public CategoryService(IGenericRepository<Category> repository, IMapper mapper)
        {
           _repository = repository;
  _mapper = mapper;
    }

        public async Task AddAsync(CategoryDto dto)
      {
         var category = _mapper.Map<Category>(dto);
 await _repository.AddAsync(category);
    }

        public async Task DeleteAsync(int id)
       {
    await _repository.DeleteAsync(id);
        }

   public async Task<IEnumerable<CategoryDto>> GetAllAsync()
      {
   var categories = await _repository.GetAllAsync();
          return _mapper.Map<IEnumerable<CategoryDto>>(categories);
    }

       public async Task<CategoryDto> GetByIdAsync(int id)
     {
    var category = await _repository.GetByIdAsync(id);
      return _mapper.Map<CategoryDto>(category);
      }

       public async Task UpdateAsync(CategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
           await _repository.UpdateAsync(category);
     }
    }
}
