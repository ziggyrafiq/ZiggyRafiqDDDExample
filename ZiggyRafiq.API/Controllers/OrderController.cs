using ZiggyRafiq.Domain.ValueObjects;

namespace ZiggyRafiq.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly OrderService _orderService;

    public OrderController(OrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public IActionResult PlaceOrder([FromBody] OrderDto orderDto)
    {
        
        var customer = new Customer(orderDto.CustomerName, orderDto.CustomerEmail,new Address("123 Street Name", "London", "SW1 1AB"));
        var order = new Order(customer);

        foreach (var item in orderDto.Items)
        {
            var orderItem = new OrderItem(item.ProductName, item.UnitPrice, item.Quantity);
            order.AddItem(orderItem);
        }

        _orderService.PlaceOrder(order);

        return Ok(order.Id);
    }

    [HttpDelete("{orderId}")]
    public IActionResult CancelOrder(Guid orderId)
    {
        _orderService.CancelOrder(orderId);
        return NoContent();
    }
}


 
