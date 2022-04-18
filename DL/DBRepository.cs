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

    List<StoreFront> IRepository.AllStoreFronts => throw new NotImplementedException();

    void IRepository.CreateOrder(Order order)
    {

    }

    public void CreateCart(Order order)
    {
        
    }

    void IRepository.AddProduct(Product product)
    {
        
    }

    public void UpdateInventory(Order order)
    {
        
    }


    

    void IRepository.CreateShopCart(Order order)
    {
        throw new NotImplementedException();
    }

    List<StoreFront> IRepository.GetStoreFronts()
    {
        throw new NotImplementedException();
    }

    public void UpdateStoreFrontFrontInv(Order order)
    {
        throw new NotImplementedException();
    }

    StoreFront IRepository.GetStoreFrontInv(StoreFront currentStoreFront)
    {
        throw new NotImplementedException();
    }

    StoreFront IRepository.GetStoreFrontInv(StoreFront currentStoreFront, object currentStoreFront1)
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

    void IRepository.UpdateStoreFrontInv(Order order)
    {
        throw new NotImplementedException();
    }

    List<OrderHistory> IRepository.GetOrderHistoryC(Customer Customer)
    {
        throw new NotImplementedException();
    }

    List<Customer> IRepository.GetAllCustomers()
    {
        throw new NotImplementedException();
    }

    public Customer CreateCustomer(Customer CustomerAdd)
    {
        throw new NotImplementedException();
    }
}
