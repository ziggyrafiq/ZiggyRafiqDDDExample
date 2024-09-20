namespace ZiggyRafiq.Domain.Models;

public record OrderItem(Guid Id, string ProductName, decimal UnitPrice, int Quantity)
{
    // Constructor for initializing without the Id
    public OrderItem(string productName, decimal unitPrice, int quantity)
        : this(Guid.NewGuid(), productName, unitPrice, quantity)
    {
    }

    // TotalPrice calculated property
    public decimal TotalPrice => UnitPrice * Quantity;
}
