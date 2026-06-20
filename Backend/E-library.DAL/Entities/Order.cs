namespace E_library.DAL.Entities
{
    public class Order : BaseEntity
    {
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
        public ICollection<OrderItem> Items { get; set; }
    }
}

public enum OrderStatus
{
    Pending,
    Denied,
    Accepted,
}
