using E_library.BLL.DTOs;

namespace E_library.BLL.Services.Interface
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<CategoryDto> GetByIdAsync(int id);
        Task AddAsync(CategoryDto dto);
     Task UpdateAsync(CategoryDto dto);
        Task DeleteAsync(int id);
    }
}
