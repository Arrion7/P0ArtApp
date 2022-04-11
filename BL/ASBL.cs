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

    public Customer CreateCustomer(Customer newCustomer)
    {
        return _repo.CreateCustomer(newCustomer);
    }

    public int LoginChecker(Customer login)
    {
        return _repo.LoginChecker(login);
    }

    public Customer GetCustomer(Customer customer)
    {
        return _repo.GetCustomer(customer);
    }

    public Product CreateProduct(Product newProduct)
    {
        throw new NotImplementedException();
    }

    public Product GetProducts(int id)
    {
        throw new NotImplementedException();
    }

    public List<Product> GetProducts(Store getProductStore)
    {
        throw new NotImplementedException();
    }

    public List<Product> GetProducts(StoreFrontId getProductStore)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Product CreateProduct(Product newProduct)
    {
        return _repo.CreateProduct(newProduct);
    }
    public Product GetProduct(int id)
    {
        return _repo.GetProduct(id);
    }
    public List GetProducts(StoreFrontId getProduct)
    {
        return _repo.GetProducts(getProduct);
    }

    public List<StoreFront> GetStoreFronts()
    {
        return _repo.GetStoreFronts();
    }

    public Order UpdateOrders(Order updateOrder)
    {
        return _repo.UpdateOrders(updateOrder);
    }
}