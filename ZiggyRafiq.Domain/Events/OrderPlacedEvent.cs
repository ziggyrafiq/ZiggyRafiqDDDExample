using MediatR;

namespace ZiggyRafiq.Domain.Events;

public class OrderPlacedEvent : INotification
{
    public Guid OrderId { get; }

    public OrderPlacedEvent(Guid orderId)
    {
        OrderId = orderId;
    }
}

