using E_library.BLL.DTOs;

namespace E_library.BLL.Services.Interface
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetAllAsync();
   Task<OrderDto> GetByIdAsync(int id);
        Task AddAsync(OrderDto dto);
        Task UpdateAsync(OrderDto dto);
     Task DeleteAsync(int id);
    }
}
