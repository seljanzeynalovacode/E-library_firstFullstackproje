using AutoMapper;
using E_library.BLL.DTOs;
using E_library.BLL.Services.Interface;
using E_library.DAL.Entities;
using E_library.DAL.Repository;

namespace E_library.BLL.Services.Implementation
{
    public class BookService : IBookService
    {
        private readonly IGenericRepository<Book> _repository;
        private readonly IMapper _mapper;

        public BookService(IGenericRepository<Book> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(BookDto dto)
        {
            var book = _mapper.Map<Book>(dto);
            await _repository.AddAsync(book);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<BookDto>> GetAllAsync()
        {
            var books = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task<BookDto> GetByIdAsync(int id)
        {
            var book = await _repository.GetByIdAsync(id);
            return _mapper.Map<BookDto>(book);
        }

        public async Task UpdateAsync(BookDto dto)
        {
            var book = _mapper.Map<Book>(dto);
            await _repository.UpdateAsync(book);
        }
    }
}
