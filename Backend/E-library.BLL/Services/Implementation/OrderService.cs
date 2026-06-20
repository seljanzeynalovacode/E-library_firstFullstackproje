using AutoMapper;
using E_library.BLL.DTOs;
using E_library.BLL.Services.Interface;
using E_library.DAL.Entities;
using E_library.DAL.Repository;

namespace E_library.BLL.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> _orderRepo;
        private readonly IGenericRepository<OrderItem> _itemRepo;
        private readonly IMapper _mapper;

        public OrderService(IGenericRepository<Order> orderRepo, IGenericRepository<OrderItem> itemRepo, IMapper mapper)
        {
            _orderRepo = orderRepo;
            _itemRepo = itemRepo;
            _mapper = mapper;
        }

        public async Task AddAsync(OrderDto dto)
        {
            // Create with Pending status
            var entity = new Order
            {
                Status = OrderStatus.Pending
            };

            await _orderRepo.AddAsync(entity);

            if (dto.Items != null && dto.Items.Count > 0)
            {
                foreach (var it in dto.Items)
                {
                    var item = new OrderItem
                    {
                        BookId = it.BookId,
                        Quantity = it.Quantity,
                        Price = it.Price,
                        OrderId = entity.Id
                    };
                    await _itemRepo.AddAsync(item);
                }
            }

            dto.Id = entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            await _orderRepo.DeleteAsync(id);
        }

        public async Task<IEnumerable<OrderDto>> GetAllAsync()
        {
            var data = await _orderRepo.GetAllAsync();
            var result = new List<OrderDto>();
            foreach (var o in data)
            {
                result.Add(new OrderDto
                {
                    Id = o.Id,
                    OrderStatus = o.Status.ToString(),
                    Items = new List<OrderItemDto>()
                });
            }
            return result;
        }

        public async Task<OrderDto> GetByIdAsync(int id)
        {
            var data = await _orderRepo.GetByIdAsync(id);
            if (data == null) throw new KeyNotFoundException($"Order with id {id} not found.");

            var items = (await _itemRepo.GetAllAsync()).Where(i => i.OrderId == id);

            return new OrderDto
            {
                Id = data.Id,
                OrderStatus = data.Status.ToString(),
                Items = items.Select(i => new OrderItemDto { BookId = i.BookId, Quantity = i.Quantity, Price = i.Price }).ToList()
            };
        }

        public async Task UpdateAsync(OrderDto dto)
        {
            var entity = new Order
            {
                Id = dto.Id,
                Status = Enum.TryParse<OrderStatus>(dto.OrderStatus, out var parsed) ? parsed : OrderStatus.Pending
            };

            await _orderRepo.UpdateAsync(entity);

            // For simplicity, not handling order items update; real implementation should sync items.
        }
    }
}
