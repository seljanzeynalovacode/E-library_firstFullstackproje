using E_library.BLL.DTOs;

namespace E_library.BLL.Services.Interface
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDto>> GetAllAsync();
        Task<AuthorDto> GetByIdAsync(int id);
     Task AddAsync(AuthorDto dto);
        Task UpdateAsync(AuthorDto dto);
      Task DeleteAsync(int id);
    }
}
