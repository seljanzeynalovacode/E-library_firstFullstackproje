namespace E_library.BLL.DTOs
{
  public record OrderItemDto : BaseDto
    {
    public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int OrderId { get; set; }
     public int BookId { get; set; }
    }
}
