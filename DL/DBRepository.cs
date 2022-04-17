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
    public Store GetStoreInventory(Store currentStore)
    {

    }

    public List<User> GetAllUsers()
    {

        List<User> users = new List<User>();
    }
    public List<Store> GetAllStores()
    {
        List<Store> stores = new List<Store>();
    }

    public List<OrderHistory> GetOrderHistoryByUser(User user)
    {
        List<OrderHistory> userOrderHistory = new List<OrderHistory>();
        List<Store> stores = GetAllStores();

        return userOrderHistory;
    }

    public List<OrderHistory> GetOrderHistoryByStore(Store _store)
    {
        
    }
   
    public User CreateUser(User userToAdd)
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

    public StoreFront GetStoreFrontInv(StoreFront currentStoreFront, object currentStoreFront1)
    {
        throw new NotImplementedException();
    }

    public List<Customer> GetAllCustomers()
    {
        throw new NotImplementedException();
    }

    public List<StoreFront> GetAllStoreFronts()
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

    public void CreateShopCart(Order order)
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

    public StoreFront GetStoreFrontInv(StoreFront currenStoreFront)
    {
        throw new NotImplementedException();
    }
}
