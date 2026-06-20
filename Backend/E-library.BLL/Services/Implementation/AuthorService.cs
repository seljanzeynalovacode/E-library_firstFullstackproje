using AutoMapper;
using E_library.BLL.DTOs;
using E_library.BLL.Services.Interface;
using E_library.DAL.Entities;
using E_library.DAL.Repository;

namespace E_library.BLL.Services.Implementation
{
    public class AuthorService : IAuthorService
    {
        private readonly IGenericRepository<Author> _repository;
        private readonly IMapper _mapper;

        public AuthorService(IGenericRepository<Author> repository, IMapper mapper)
     {
      _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(AuthorDto dto)
      {
            var author = _mapper.Map<Author>(dto);
            await _repository.AddAsync(author);
     }

        public async Task DeleteAsync(int id)
        {
       await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAsync()
        {
            var authors = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<AuthorDto>>(authors);
        }

public async Task<AuthorDto> GetByIdAsync(int id)
     {
     var author = await _repository.GetByIdAsync(id);
        return _mapper.Map<AuthorDto>(author);
        }

      public async Task UpdateAsync(AuthorDto dto)
        {
 var author = _mapper.Map<Author>(dto);
          await _repository.UpdateAsync(author);
        }
    }
}
