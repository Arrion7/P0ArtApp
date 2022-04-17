using Models;
namespace DL;

public interface IRepository
{
    StoreFront GetStoreFrontInv(StoreFront currentStoreFront, object currentStoreFront1);
    List<Customer> GetAllCustomers();
    List<StoreFront> GetAllStoreFronts();
    List<OrderHistory> GetOrderHistoryC(Customer Customer);
    List<OrderHistory> GetOrderHistorySF(StoreFront _StoreFront);
    Customer CreateCustomer(Customer CustomerAdd);
    void CreateOrder(Order order);
    void CreateShopCart(Order order);
    List<StoreFront> GetStoreFronts();
    void AddProduct(Product product);
    void UpdateStoreFrontInv(Order order);
    StoreFront GetStoreFrontInv(StoreFront currenStoreFront);
}

public class OrderHistory
{
    public int OrderId { get; internal set; }
    public List<StoreFront> StoreFront { get; internal set; }
    public string ProductName { get; internal set; }
}