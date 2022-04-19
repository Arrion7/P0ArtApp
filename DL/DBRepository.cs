using Microsoft.Data.SqlClient;
using System.Data;
using Models;

namespace DL;
public class DBRepository : IRepository
{
    private readonly string _connectionString;

    public List<StoreFront> AllStoreFronts => throw new NotImplementedException();

    public DBRepository(string connectionString)
    {
        _connectionString = connectionString;
    }
    public void CreateOrder(Order order)
    {

    }

    public void CreateShopCart(Order order)
    {
        
    }

    public void UpdateInventory(Order order)
    {
        
    }

    public StoreFront GetStoreFrontInv(StoreFront currentStoreFront, object currentStoreFront1)
    {
        throw new NotImplementedException();
    }

    public List<Customer> GetAllCustomers()
    {
        throw new NotImplementedException();
    }

    public List<OrderHistory> GetOrderHistoryC(Customer Customer)
    {
        throw new NotImplementedException();
    }

    public List<OrderHistory> GetOrderHistorySF(StoreFront _StoreFront)
    {
        throw new NotImplementedException();
    }

    public Customer CreateCustomer(Customer CustomerAdd)
    {
        throw new NotImplementedException();
    }

    public void AddProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public void UpdateStoreFrontInv(Order order)
    {
        throw new NotImplementedException();
    }

    public StoreFront GetStoreFrontInv(StoreFront currentStoreFront)
    {
        throw new NotImplementedException();
    }

    public Customer addCustomer(Customer customerAdd)
    {
        throw new NotImplementedException();
    }

    public void addToOrder(Order Order)
    {
        throw new NotImplementedException();
    }

    public List<StoreFront> GetAllStoreFronts()
    {
        throw new NotImplementedException();
    }

    public StoreFront StoreFrontInv(StoreFront currentStoreFront)
    {
        throw new NotImplementedException();
    }

    public Customer AddCustomer(Customer customerAdd)
    {
        throw new NotImplementedException();
    }
}
