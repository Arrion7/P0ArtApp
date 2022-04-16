using DL;
using Models;

namespace BL;

public class Asbl : IAsbl
{
    private readonly IRepository _repo;

    public Asbl(IRepository repo)
    {
        _repo = repo;
    }

    public Customer addCustomer(Customer customerAdd)
    {
        return _repo.CreateAccount(customerAdd);
    }

    public void addToOrder(Order order)
    {
        _repo.createOrder(order);
    }

    public List<StoreFront> GetAllStoreFronts()
    {
        return _repo.GetStoreFronts();
    }

    public StoreFront GetStoreFrontInv(StoreFront currenStoreFront)
    {
        return _repo.GetStoreFrontInv(currenStoreFront);
    }

    public List<OrderHistory> GetOrderHistorySF(StoreFront _StoreFront)
    {
        List<OrderHistory> OrderHistorySF = _repo.GetOrderHistorySF(_StoreFront);
        return OrderHistorySF;
    }

    public List<OrderHistory> GetOrderHistoryC(Customer customer)
    {
        List<OrderHistory> OrderHistoryC = _.GetOrderHistoryC(customer);
        return OrderHistoryC;
    }

}