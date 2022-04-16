using Models;

namespace UI;

public interface IAsbl
{
    List<Customer> GetAllCustomers();
    Customer addCustomer(Customer customerAdd);
    void addToOrder(Order order);
    List<StoreFront> GetAllStoreFronts();
    StoreFront getStoreFrontInv(StoreFront currentStoreFront);
    List<OrderHistory> GetOrderHistorySF(StoreFront _StoreFront);
    List<OrderHistory> GetOrderHistoryC(Customer customer);
}

public class OrderHistory
{
    public readonly object? Customer;
    public readonly object? DateOrdered;
}