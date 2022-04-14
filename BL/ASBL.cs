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

    public int LoginValid(Customer login)
    {
        return _repo.LoginValid(login);
    }

    public Customer GetCustomer(Customer existCustomer)
    {
        return _repo.GetCustomer(existCustomer);
    }

    public Product CreateProduct(Product newProduct)
    {
        return _repo.CreateProduct(newProduct);
    }

    public Product GetProduct(int id)
    {
        return _repo.GetProduct(id);
    }

    public List<Product> GetProducts (StoreFrontId getProducts)
    {
        return _repo.GetProducts(getProducts);
    }

    public List<StoreFrontId> GetStoreFrontIds()
    {
        return _repo.GetStoreFrontIds();
    }

    public Order UpdateOrders(Order updateOrder)
    {
        return _repo.UpdateOrders(updateOrder);
    }

    public Product CreateProduct(Product newProduct, Product newProduct1)
    {
        throw new NotImplementedException();
    }

    public Product GetProducts(int id)
    {
        throw new NotImplementedException();
    }
}