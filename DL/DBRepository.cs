using Models;

namespace DL;

public class DbRepository : IRepository
{
    public readonly string ConnectionString;
    public DbRepository(string connectionString)
    {
        this.ConnectionString = connectionString;
    }

    public Customer CreateCustomer(Customer newCustomer)
    {
        throw new NotImplementedException();
    }

    public Product CreateProduct(Product newProduct)
    {
        throw new NotImplementedException();
    }

    public Customer GetCustomer(Customer customer)
    {
        throw new NotImplementedException();
    }

    public Product GetProduct(int id)
    {
        throw new NotImplementedException();
    }

    public List<Product> GetProducts(StoreFrontId getProduct)
    {
        throw new NotImplementedException();
    }

    public List<Product> GetProduct(StoreFrontId getProduct)
    {
        throw new NotImplementedException();
    }

    public List<StoreFrontId> GetStoreFrontId()
    {
        throw new NotImplementedException();
    }

    public List<StoreFrontId> GetStoreFrontIds()
    {
        throw new NotImplementedException();
    }

    public int LoginChecker(Customer login)
    {
        throw new NotImplementedException();
    }

    public Order UpdateOrders(Order updateOrder)
    {
        throw new NotImplementedException();
    }


    List<StoreFrontId> IRepository.GetStoreFrontIds()
    {
        throw new NotImplementedException();
    }

    public List<StoreFrontId> GetStoreFrontIdFronts()
    {
        throw new NotImplementedException();
    }
}