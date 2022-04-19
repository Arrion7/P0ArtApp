using DL;

namespace BL;

public class Asbl : IAsbl
{
    private readonly IRepository _repo;

    public Asbl(IRepository repo)
    {
        _repo = repo;
    }

    public List<Customer> GetAllCustomers()
    {
        return _repo.GetAllCustomers();
    }

    public Customer AddCustomer(Customer customerAdd)
    {
        return _repo.CreateCustomer(customerAdd);
    }

    public void AddOrder(Order order)
    {
        _repo.CreateOrder(order);
    }

    public List<StoreFront> GetAllStoreFronts()
    {
        return _repo.GetAllStoreFronts();
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

    List<Customer> IAsbl.GetAllCustomers()
    {
        throw new NotImplementedException();
    }

    Customer IAsbl.addCustomer(Customer customerAdd)
    {
        throw new NotImplementedException();
    }

    void IAsbl.addToOrder(Order order)
    {
        throw new NotImplementedException();
    }

    List<StoreFront> IAsbl.GetAllStoreFronts()
    {
        throw new NotImplementedException();
    }

    StoreFront IAsbl.getStoreFrontInv(StoreFront currentStoreFront)
    {
        throw new NotImplementedException();
    }

    List<OrderHistory> IAsbl.GetOrderHistorySF(StoreFront _StoreFront)
    {
        throw new NotImplementedException();
    }

    List<OrderHistory> IAsbl.GetOrderHistoryC(Customer customer)
    {
        throw new NotImplementedException();
    }
}