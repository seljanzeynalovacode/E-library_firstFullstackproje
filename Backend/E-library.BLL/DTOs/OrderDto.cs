using System.Collections.Generic;

namespace E_library.BLL.DTOs
{
 public record OrderDto : BaseDto
 {
 public decimal TotalAmount { get; set; }
 public string OrderStatus { get; set; }
 public List<OrderItemDto> Items { get; set; }
 }
}
