using MediatR;
using ZiggyRafiq.Domain.Events;
using ZiggyRafiq.Domain.Models;
using ZiggyRafiq.Domain.Repository;

namespace ZiggyRafiq.Domain.Services;

public class OrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMediator _mediator;

    public OrderService(IOrderRepository orderRepository, IMediator mediator)
    {
        _orderRepository = orderRepository;
        _mediator = mediator;
    }

    public async Task PlaceOrder(Order order)
    {
        if (order.TotalAmount <= 0)
            throw new InvalidOperationException("Order total must be greater than zero.");

        _orderRepository.Add(order);
        await _mediator.Publish(new OrderPlacedEvent(order.Id));
    }

    public void CancelOrder(Guid orderId)
    {
        var order = _orderRepository.GetById(orderId);
        if (order == null)
            throw new InvalidOperationException("Order not found.");

        _orderRepository.Delete(order);
    }
}
