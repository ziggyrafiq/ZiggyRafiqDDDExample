using ZiggyRafiq.Domain.ValueObjects;

namespace ZiggyRafiq.Tests;

public class OrderServiceTests
{
    private readonly Mock<IOrderRepository> _orderRepositoryMock;
    private readonly Mock<IMediator> _mediatorMock;
    private readonly OrderService _orderService;

    public OrderServiceTests()
    {
        _orderRepositoryMock = new Mock<IOrderRepository>();
        _mediatorMock = new Mock<IMediator>();
        _orderService = new OrderService(_orderRepositoryMock.Object, _mediatorMock.Object);
    }

    [Fact]
    public async Task PlaceOrder_ShouldPublishOrderPlacedEvent()
    {
        // Arrange
        var customer = new Customer("Tom Jack", "tom.jack@example.com", new  Address("123 Street Name","London", "SW1 1AB"));
        var order = new Order(customer);
        order.AddItem(new OrderItem("Product A", 10, 2));

        // Act
        await _orderService.PlaceOrder(order);

        // Assert
        _orderRepositoryMock.Verify(r => r.Add(It.IsAny<Order>()), Times.Once);
        _mediatorMock.Verify(m => m.Publish(It.IsAny<OrderPlacedEvent>(), default), Times.Once);
    }
}
