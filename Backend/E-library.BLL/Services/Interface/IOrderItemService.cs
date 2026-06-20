using E_library.BLL.DTOs;

namespace E_library.BLL.Services.Interface
{
    public interface IOrderItemService
    {
 Task<IEnumerable<OrderItemDto>> GetAllAsync();
       Task<OrderItemDto> GetByIdAsync(int id);
     Task AddAsync(OrderItemDto dto);
        Task UpdateAsync(OrderItemDto dto);
        Task DeleteAsync(int id);
    }
}
