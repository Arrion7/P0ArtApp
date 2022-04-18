using Microsoft.Data.SqlClient;
using System.Data;
using Models;

namespace DL;
public class DBRepository : IRepository
{
    private readonly string _connectionString;

    public DBRepository(string connectionString)
    {
        _connectionString = connectionString;
    }
    public StoreFront GetStoreFrontInv(StoreFront currentStoreFront)
    {

    }

    public List<Customer> GetAllCustomers()
    {

        List<Customer> Customers = new List<Customer>();
    }
    public List<StoreFront> GetAllStoreFronts()
    {
        List<StoreFront> StoreFronts = new List<StoreFront>();
    }

    public List<OrderHistory> GetOrderHistoryByCustomer(Customer Customer)
    {
        List<OrderHistory> CustomerOrderHistory = new List<OrderHistory>();
        List<StoreFront> StoreFronts = GetAllStoreFronts();

        return CustomerOrderHistory;
    }

    public List<OrderHistory> GetOrderHistoryByStoreFront(StoreFront _StoreFront)
    {
        
    }
    public Customer CreateCustomer(Customer CustomerToAdd)
    {

    }

    public void CreateOrder(Order order)
    {

    }

    public void CreateCart(Order order)
    {
        
    }

    public void AddProduct(Product product)
    {
        
    }

    public void UpdateInventory(Order order)
    {
        
    }


    

    public void CreateShopCart(Order order)
    {
        throw new NotImplementedException();
    }

    public List<StoreFront> GetStoreFronts()
    {
        throw new NotImplementedException();
    }

    public void UpdateStoreFrontFrontInv(Order order)
    {
        throw new NotImplementedException();
    }

    public StoreFront GetStoreFrontInv(StoreFront currentStoreFront)
    {
        throw new NotImplementedException();
    }

    public StoreFront GetStoreFrontInv(StoreFront currentStoreFront, object currentStoreFront1)
    {
        throw new NotImplementedException();
    }

    public List<OrderHistory> GetOrderHistorySF(StoreFront _StoreFront)
    {
        throw new NotImplementedException();
    }

    public List<StoreFront> GetStoreFronts()
    {
        throw new NotImplementedException();
    }

    public void UpdateStoreFrontInv(Order order)
    {
        throw new NotImplementedException();
    }

    public List<OrderHistory> GetOrderHistoryC(Customer Customer)
    {
        throw new NotImplementedException();
    }
}
