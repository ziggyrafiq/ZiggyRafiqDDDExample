
using Microsoft.EntityFrameworkCore;
using ZiggyRafiq.Domain.Models;
using ZiggyRafiq.Domain.Repository;

namespace ZiggyRafiq.Infrastructure;

public class OrderRepository : IOrderRepository
{
    private readonly DbEntities _context;

    public OrderRepository(DbEntities context)
    {
        _context = context;
    }

    public Order GetById(Guid orderId)
    {
        return _context.Orders
            .Include(o => o.Items)
            .Include(o => o.Customer)
            .SingleOrDefault(o => o.Id == orderId);
    }

    public void Add(Order order)
    {
        _context.Orders.Add(order);
        _context.SaveChanges();
    }

    public void Update(Order order)
    {
        _context.Orders.Update(order);
        _context.SaveChanges();
    }

    public void Delete(Order order)
    {
        _context.Orders.Remove(order);
        _context.SaveChanges();
    }
}
