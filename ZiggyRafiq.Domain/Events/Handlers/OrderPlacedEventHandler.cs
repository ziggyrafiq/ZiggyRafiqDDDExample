using MediatR;
namespace ZiggyRafiq.Domain.Events.Handlers;
public class OrderPlacedEventHandler : INotificationHandler<OrderPlacedEvent>
{
    public Task Handle(OrderPlacedEvent notification, CancellationToken cancellationToken)
    {
        // Logic to handle the event, e.g., sending an email
        Console.WriteLine($"Order placed with ID: {notification.OrderId}");

        // For example, send a notification email to the customer
        // EmailService.SendOrderConfirmation(notification.OrderId);

        return Task.CompletedTask;
    }
}
