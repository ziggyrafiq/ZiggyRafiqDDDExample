using ZiggyRafiq.Domain.Models;

namespace ZiggyRafiq.Domain.Repository;

public interface IOrderRepository
{
    Order GetById(Guid orderId);
    void Add(Order order);
    void Update(Order order);
    void Delete(Order order);
}
