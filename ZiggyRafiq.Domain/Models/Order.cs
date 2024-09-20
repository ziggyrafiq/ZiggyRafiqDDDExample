namespace ZiggyRafiq.Domain.Models;
public record Order(Guid Id, DateTime OrderDate, Customer Customer, List<OrderItem> Items)
{
    // Constructor with only customer as parameter
    public Order(Customer customer)
        : this(Guid.NewGuid(), DateTime.UtcNow, customer ?? throw new ArgumentNullException(nameof(customer)), new List<OrderItem>())
    {
    }

    // AddItem method for adding items
    public void AddItem(OrderItem item)
    {
        if (item == null) throw new ArgumentNullException(nameof(item));
        Items.Add(item);
    }

    // TotalAmount calculated property
    public decimal TotalAmount => Items.Sum(i => i.TotalPrice);
}


