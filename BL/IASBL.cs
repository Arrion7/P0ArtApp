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
    List<OrderHistory> GetOrderHistoryByCustomer(Customer customer);
}

public class OrderHistory
{
    public static object? StoreFrontName;
    public readonly object? Customer;
    public readonly object? DateOrdered;
    public readonly object? Customeremail;
    public object? ArtSupplyPrice;
    public object? ArtSupplyQty;

    public static object? Name { get; set; }
    public static object? ProductName { get; set; }
    public object? StoreFront { get; set; }
}