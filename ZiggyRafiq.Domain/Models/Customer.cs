using ZiggyRafiq.Domain.ValueObjects;

namespace ZiggyRafiq.Domain.Models;
public record Customer(Guid Id, string Name, string Email)
{
    public Address? Address { get; set; }

    public Customer(string name, string email, Address address)
        : this(Guid.NewGuid(), name ?? throw new ArgumentNullException(nameof(name)),
              email ?? throw new ArgumentNullException(nameof(email)))
    {
        Address = address ?? throw new ArgumentNullException(nameof(address));
    }
}