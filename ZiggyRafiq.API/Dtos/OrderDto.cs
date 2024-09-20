namespace ZiggyRafiq.API.Dtos;

public class OrderDto
{
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerEmail { get; set; } = string.Empty;
    public List<OrderItemDto> Items { get; set; }
}
