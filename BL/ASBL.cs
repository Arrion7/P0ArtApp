using DL;
using OrderHistory = DL.OrderHistory;

namespace BL;

public class Asbl : IAsbl
{
    private readonly IRepository _repo;

    public Asbl(IRepository repo)
    {
        _repo = repo;
    }

    public void addToOrder(Order order)
    {
        _repo.CreateOrder(order);
    }

    public List<StoreFront> GetAllStoreFronts()
    {
        return _repo.GetStoreFronts();
    }

    public StoreFront GetStoreFrontInv(StoreFront currentStoreFront)
    {
        return _repo.GetStoreFrontInv(currentStoreFront);
    }

    public List<OrderHistory> GetOrderHistorySF(StoreFront _StoreFront)
    {
        List<OrderHistory> OrderHistorySF = _repo.GetOrderHistorySF(_StoreFront);
        return OrderHistorySF;
    }

    public List<OrderHistory> GetOrderHistoryC(Customer customer)
    {
        List<OrderHistory> OrderHistoryC = _repo.GetOrderHistoryC(customer);
        return OrderHistoryC;
    }

}

public interface IAsbl
{
}